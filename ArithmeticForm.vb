Imports System.Windows.Forms

Public Class ArithmeticForm
    Inherits Form

    Private grade As Integer
    Private num1 As Integer
    Private num2 As Integer
    Private trials As Integer = 0

    Private lblGrade As Label
    Private cbGrade As ComboBox
    Private btnGenerate As Button
    Private lblNumber1 As Label
    Private lblNumber2 As Label
    Private lblOperator As Label
    Private txtOperator As TextBox
    Private lblAnswer As Label
    Private txtAnswer As TextBox
    Private btnSubmit As Button
    Private lblFeedback As Label
    Private btnExit As Button

    Public Sub New(age As Integer)
        ' Form settings
        Me.Text = "Arithmetic Practice"
        Me.Size = New Drawing.Size(400, 300)

        ' Initialize controls
        lblGrade = New Label With {
            .Text = "Select Grade:",
            .Location = New Drawing.Point(10, 20),
            .AutoSize = True
        }
        cbGrade = New ComboBox With {
            .Location = New Drawing.Point(100, 20),
            .DropDownStyle = ComboBoxStyle.DropDownList
        }
        btnGenerate = New Button With {
            .Text = "Generate Random Numbers",
            .Location = New Drawing.Point(10, 60)
        }
        lblNumber1 = New Label With {
            .Location = New Drawing.Point(10, 100),
            .AutoSize = True
        }
        lblNumber2 = New Label With {
            .Location = New Drawing.Point(100, 100),
            .AutoSize = True
        }
        lblOperator = New Label With {
            .Text = "Operator:",
            .Location = New Drawing.Point(10, 140),
            .AutoSize = True
        }
        txtOperator = New TextBox With {
            .Location = New Drawing.Point(100, 140)
        }
        lblAnswer = New Label With {
            .Text = "Answer:",
            .Location = New Drawing.Point(10, 180),
            .AutoSize = True
        }
        txtAnswer = New TextBox With {
            .Location = New Drawing.Point(100, 180)
        }
        btnSubmit = New Button With {
            .Text = "Submit",
            .Location = New Drawing.Point(10, 220)
        }
        lblFeedback = New Label With {
            .Location = New Drawing.Point(10, 260),
            .AutoSize = True
        }
        btnExit = New Button With {
            .Text = "Exit",
            .Location = New Drawing.Point(100, 220)
        }

        ' Add controls to the form
        Me.Controls.Add(lblGrade)
        Me.Controls.Add(cbGrade)
        Me.Controls.Add(btnGenerate)
        Me.Controls.Add(lblNumber1)
        Me.Controls.Add(lblNumber2)
        Me.Controls.Add(lblOperator)
        Me.Controls.Add(txtOperator)
        Me.Controls.Add(lblAnswer)
        Me.Controls.Add(txtAnswer)
        Me.Controls.Add(btnSubmit)
        Me.Controls.Add(lblFeedback)
        Me.Controls.Add(btnExit)

        ' Add items to ComboBox
        cbGrade.Items.Add("Grade 1")
        cbGrade.Items.Add("Grade 2")
        cbGrade.Items.Add("Grade 3")
        cbGrade.SelectedIndex = age - 4

        ' Add event handlers
        AddHandler btnGenerate.Click, AddressOf Me.BtnGenerate_Click
        AddHandler btnSubmit.Click, AddressOf Me.BtnSubmit_Click
        AddHandler btnExit.Click, AddressOf Me.BtnExit_Click
    End Sub

    Private Sub BtnGenerate_Click(sender As Object, e As EventArgs)
        ' Generate random numbers based on grade
        Dim rand As New Random()
        Select Case cbGrade.SelectedIndex + 1
            Case 1
                num1 = rand.Next(1, 10)
                num2 = rand.Next(1, 10)
            Case 2, 3
                num1 = rand.Next(10, 100)
                num2 = rand.Next(10, 100)
        End Select
        lblNumber1.Text = num1.ToString()
        lblNumber2.Text = num2.ToString()
        lblFeedback.Text = ""
        txtOperator.Text = ""
        txtAnswer.Text = ""
        trials = 0
    End Sub

    Private Sub BtnSubmit_Click(sender As Object, e As EventArgs)
        Dim op As String = txtOperator.Text
        Dim answer As Integer
        If Not Integer.TryParse(txtAnswer.Text, answer) Then
            MessageBox.Show("Answer must be a number.")
            Return
        End If

        Dim correctAnswer As Integer
        Select Case op
            Case "+"
                correctAnswer = num1 + num2
            Case "-"
                correctAnswer = num1 - num2
            Case "*"
                correctAnswer = num1 * num2
            Case "/"
                If num2 = 0 Then
                    MessageBox.Show("Cannot divide by zero.")
                    Return
                End If
                correctAnswer = num1 / num2
            Case Else
                MessageBox.Show("Invalid operator.")
                Return
        End Select

        If answer = correctAnswer Then
            lblFeedback.Text = "Correct!"
        Else
            lblFeedback.Text = "Try again."
            trials += 1
            If trials >= 5 Then
                lblFeedback.Text = $"Correct answer: {correctAnswer}"
            End If
        End If
    End Sub

    Private Sub BtnExit_Click(sender As Object, e As EventArgs)
        If MessageBox.Show("Do you want to quit?", "Exit", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub
End Class
