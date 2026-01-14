using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WindowBasedLearningPlatform.WindowApp.Models;
using WindowBasedLearningPlatform.WindowApp.Models.QuizModel;
using WindowBasedLearningPlatform.WindowApp.Services;

namespace WindowBasedLearningPlatform.WindowApp.App.UserControls
{
    public partial class UC_QuizViewer : UserControl
    {
        private int _lessonId;
        private List<QuizQuestion> _questions;
        private int _currentIndex = 0;
        private int _score = 0;

        // UI Controls
        private Label lblQuestion;
        private RadioButton rbA, rbB, rbC, rbD;
        private Button btnSubmit;
        private Label lblResult;

        public UC_QuizViewer(int lessonId)
        {
            InitializeComponent();
            _lessonId = lessonId;
            SetupUI();
            LoadQuestions();
        }

        private void SetupUI()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.White;
            this.Padding = new Padding(40);

            // Title
            Label lblTitle = new Label();
            lblTitle.Text = "Lesson Quiz";
            lblTitle.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Height = 60;
            this.Controls.Add(lblTitle);

            // Container
            Panel panel = new Panel();
            panel.Dock = DockStyle.Fill;
            this.Controls.Add(panel);
            panel.BringToFront();

            // Question Text
            lblQuestion = new Label();
            lblQuestion.Text = "Loading...";
            lblQuestion.Font = new Font("Segoe UI", 14);
            lblQuestion.AutoSize = true;
            lblQuestion.Location = new Point(0, 20);
            panel.Controls.Add(lblQuestion);

            // Options
            rbA = CreateRadioButton(0, 80);
            rbB = CreateRadioButton(0, 120);
            rbC = CreateRadioButton(0, 160);
            rbD = CreateRadioButton(0, 200);

            panel.Controls.Add(rbA);
            panel.Controls.Add(rbB);
            panel.Controls.Add(rbC);
            panel.Controls.Add(rbD);

            // Submit Button
            btnSubmit = new Button();
            btnSubmit.Text = "Submit Answer";
            btnSubmit.BackColor = ColorTranslator.FromHtml("#fdd23f");
            btnSubmit.FlatStyle = FlatStyle.Flat;
            btnSubmit.FlatAppearance.BorderSize = 0;
            btnSubmit.Size = new Size(150, 40);
            btnSubmit.Location = new Point(0, 260);
            btnSubmit.Click += BtnSubmit_Click;
            panel.Controls.Add(btnSubmit);

            // Result Label
            lblResult = new Label();
            lblResult.Text = "";
            lblResult.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblResult.ForeColor = Color.Green;
            lblResult.Location = new Point(170, 270);
            lblResult.AutoSize = true;
            panel.Controls.Add(lblResult);
        }

        private RadioButton CreateRadioButton(int x, int y)
        {
            RadioButton rb = new RadioButton();
            rb.Font = new Font("Segoe UI", 11);
            rb.AutoSize = true;
            rb.Location = new Point(x, y);
            return rb;
        }

        private void LoadQuestions()
        {
            _questions = DatabaseService.GetQuizzesForLesson(_lessonId);
            if (_questions.Count > 0)
            {
                ShowQuestion(0);
            }
            else
            {
                lblQuestion.Text = "No questions available for this lesson.";
                btnSubmit.Enabled = false;
            }
        }

        private void ShowQuestion(int index)
        {
            if (index >= _questions.Count)
            {
                FinishQuiz();
                return;
            }

            var q = _questions[index];
            lblQuestion.Text = $"Q{index + 1}: {q.QuestionText}";
            rbA.Text = q.OptionA;
            rbB.Text = q.OptionB;
            rbC.Text = q.OptionC;
            rbD.Text = q.OptionD;

            // Reset selection
            rbA.Checked = rbB.Checked = rbC.Checked = rbD.Checked = false;
            lblResult.Text = "";
            btnSubmit.Text = "Submit Answer";
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (btnSubmit.Text == "Next Question")
            {
                _currentIndex++;
                ShowQuestion(_currentIndex);
                return;
            }

            // Check Answer
            string selected = "";
            if (rbA.Checked) selected = "A";
            else if (rbB.Checked) selected = "B";
            else if (rbC.Checked) selected = "C";
            else if (rbD.Checked) selected = "D";

            if (string.IsNullOrEmpty(selected))
            {
                MessageBox.Show("Please select an option.");
                return;
            }

            var q = _questions[_currentIndex];
            if (selected == q.CorrectOption.Trim())
            {
                _score++;
                lblResult.Text = "Correct! ✅";
                lblResult.ForeColor = Color.Green;
            }
            else
            {
                lblResult.Text = $"Wrong! Correct was {q.CorrectOption}";
                lblResult.ForeColor = Color.Red;
            }

            btnSubmit.Text = "Next Question";
        }

        private void FinishQuiz()
        {
            lblQuestion.Text = $"Quiz Completed!\nScore: {_score} / {_questions.Count}";
            rbA.Visible = rbB.Visible = rbC.Visible = rbD.Visible = false;
            btnSubmit.Visible = false;
            lblResult.Text = "";

            // TODO: Save score to database here
        }
    }
}