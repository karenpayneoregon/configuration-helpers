Imports visualBasicConnectionCodeSample.Classes

Public Class Form1
    Private Sub StandardConnection_Click(sender As Object, e As EventArgs) Handles StandardConnection.Click

        Dim personDataTable = SqlDataOperations.LoadPersonRecordsUsingDataTable()

        If SqlDataOperations.LastException IsNot Nothing Then
            MessageBox.Show($"{SqlDataOperations.LastException.Message}")
        Else
            MessageBox.Show($"Record count should be 2 -> {personDataTable.Rows.Count}")
        End If

    End Sub
End Class
