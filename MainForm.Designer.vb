<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.StatusLbl = New System.Windows.Forms.Label()
        Me.IPlbl = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(32, 41)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(158, 68)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Users Activity"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(606, 66)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 19)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Status"
        '
        'StatusLbl
        '
        Me.StatusLbl.AutoSize = True
        Me.StatusLbl.Location = New System.Drawing.Point(679, 66)
        Me.StatusLbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.StatusLbl.Name = "StatusLbl"
        Me.StatusLbl.Size = New System.Drawing.Size(46, 19)
        Me.StatusLbl.TabIndex = 1
        Me.StatusLbl.Text = "Status"
        '
        'IPlbl
        '
        Me.IPlbl.AutoSize = True
        Me.IPlbl.Location = New System.Drawing.Point(679, 104)
        Me.IPlbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.IPlbl.Name = "IPlbl"
        Me.IPlbl.Size = New System.Drawing.Size(23, 19)
        Me.IPlbl.TabIndex = 2
        Me.IPlbl.Text = "IP"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(606, 104)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(23, 19)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "IP"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(606, 141)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(96, 50)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "Load"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(708, 141)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(96, 50)
        Me.Button3.TabIndex = 5
        Me.Button3.Text = "Stop"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(978, 551)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.IPlbl)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.StatusLbl)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "MainForm"
        Me.Text = "MainForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents StatusLbl As Label
    Friend WithEvents IPlbl As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
End Class
