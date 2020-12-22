Imports System.Data.SqlClient
Imports ConfigurationHelper

Namespace Classes
    Public Class SqlDataOperations
        Private Shared ReadOnly ConnectionString As String = Helper.GetConnectionString()
        Public Shared LastException As Exception
        Public Shared Function LoadPersonRecordsUsingDataTable() As DataTable

            Dim selectStatement =
                    <SQL>
                        SELECT 
                            P.PersonID, 
                            P.LastName, 
                            P.FirstName, 
                            P.EnrollmentDate, 
                            P.Discriminator, 
                            SG.Grade, 
                            C.Title 
                        FROM Person AS P 
                            INNER JOIN StudentGrade AS SG ON P.PersonID = SG.StudentID 
                            INNER JOIN Course AS C ON SG.CourseID = C.CourseID 
                        WHERE (SG.Grade > 3.5 AND P.PersonID = 13)
                    </SQL>.Value

            Dim personDataTable = New DataTable

            Using cn As New SqlConnection With {.ConnectionString = ConnectionString}
                Using cmd As New SqlCommand With {.Connection = cn}
                    Try
                        cmd.CommandText = selectStatement

                        cn.Open()

                        personDataTable.Load(cmd.ExecuteReader())


                    Catch ex As Exception
                        LastException = ex
                    End Try
                End Using
            End Using

            Return personDataTable

        End Function
    End Class
End Namespace