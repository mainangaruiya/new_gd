Imports System.Windows.Forms

Public Class Form1
    Inherits Form

    Private lblInstruction As Label
    Private dtpDOB As DateTimePicker
    Private btnLogin As Button
    Private lblError As Label

    Public Sub New()
        ' Form settings
        Me.Text = "Login"
        Me.Size = New Drawing.Size(400, 300)

        ' Initialize controls
        lblInstruction = New Label With {
            .Text = "Enter your date of birth:",
            .Location = New Drawing.Point(10, 20),
            .AutoSize = True
        }
        dtpDOB = New DateTimePicker With {
            .Location = New Drawing.Point(10, 50)
        }
        btnLogin = New Button With {
            .Text = "Login",
            .Location = New Drawing.Point(10, 90)
        }
        lblError = New Label With {
            .Location = New Drawing.Point(10, 130),
            .AutoSize = True,
            .ForeColor = Drawing.Color.Red
        }

        ' Add controls to the form
        Me.Controls.Add(lblInstruction)
        Me.Controls.Add(dtpDOB)
        Me.Controls.Add(btnLogin)
        Me.Controls.Add(lblError)

        ' Add event handlers
        AddHandler btnLogin.Click, AddressOf Me.BtnLogin_Click
    End Sub

    Private Sub BtnLogin_Click(sender As Object, e As EventArgs)
        Dim dob As DateTime = dtpDOB.Value
        Dim age As Integer = DateTime.Now.Year - dob.Year
        If (dob > DateTime.Now.AddYears(-age)) Then age -= 1

        If age < 4 Then
            MessageBox.Show("Oops! You are too young for this.")
        ElseIf age > 8 Then
            MessageBox.Show("Ooh this is too basic for you.")
        Else
            Dim arithmeticForm As New ArithmeticForm(age)
            arithmeticForm.Show()
            Me.Hide()
        End If
    End Sub
End Class
