<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.StandardConnection = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'StandardConnection
        '
        Me.StandardConnection.Location = New System.Drawing.Point(22, 21)
        Me.StandardConnection.Name = "StandardConnection"
        Me.StandardConnection.Size = New System.Drawing.Size(137, 23)
        Me.StandardConnection.TabIndex = 0
        Me.StandardConnection.Text = "Standard connection"
        Me.StandardConnection.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(201, 70)
        Me.Controls.Add(Me.StandardConnection)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Connect sample"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents StandardConnection As Button
End Class
