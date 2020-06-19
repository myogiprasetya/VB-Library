
Imports System.Data.SqlClient

Namespace MYP100JECT.Library.Database
    Public Class QueryBuilder
        Private TableValue As String
        Private FieldValue As String
        Private ConditionValue As String
        Private OrderValue As String
        Private GroupValue As String
        Private JoinValue As String

        Public Function Table(TableName As String) As QueryBuilder
            TableValue = TableName

            Return Me
        End Function

        Public Function [Select](Field As String()) As QueryBuilder
            For Counter As Integer = 0 To Field.Length - 1
                If Counter = 0 Then
                    FieldValue = String.Empty
                Else
                    FieldValue += ", "
                End If

                FieldValue += Field(Counter)
            Next

            Return Me
        End Function

        Public Function [Select](Field As String) As QueryBuilder
            FieldValue = Field

            Return Me
        End Function

        Public Function OrWhere(Value(,) As String) As QueryBuilder
            For Counter As Integer = 0 To Value.GetLength(0) - 1
                Select Case Value.GetLength(1)
                    Case 2
                        OrWhere(Value(Counter, 0), Value(Counter, 1))
                    Case 3
                        OrWhere(Value(Counter, 0), Value(Counter, 1), Value(Counter, 2))
                End Select
            Next

            Return Me
        End Function

        Public Function OrWhere(Field As String, Value As String) As QueryBuilder
            Return OrWhere(Field, "=", Value)
        End Function

        Public Function OrWhere(Field As String, Parameter As String, Value As String) As QueryBuilder
            Where(Field, Parameter, Value, "OR")

            Return Me
        End Function

        Public Function Where(Value(,) As String) As QueryBuilder
            For Counter As Integer = 0 To Value.GetLength(0) - 1
                Select Case Value.GetLength(1)
                    Case 2
                        Where(Value(Counter, 0), Value(Counter, 1))
                    Case 3
                        Where(Value(Counter, 0), Value(Counter, 1), Value(Counter, 2))
                End Select
            Next

            Return Me
        End Function

        Public Function Where(Field As String, Value As String) As QueryBuilder
            Return Where(Field, "=", Value)
        End Function

        Public Function Where(Field As String, Parameter As String, Value As String) As QueryBuilder
            Where(Field, Parameter, Value, Nothing)

            Return Me
        End Function

        Public Function Where(Field As String, Parameter As String, Value As String, Link As String) As QueryBuilder
            If ConditionValue <> String.Empty Then
                If ConditionValue.Substring(ConditionValue.Length - 4) <> "AND " Or ConditionValue.Substring(ConditionValue.Length - 3) <> "OR " Then
                    If Link Is Nothing Then
                        ConditionValue += " AND "
                    Else
                        ConditionValue += Space(1) + Link + Space(1)
                    End If
                End If
            End If

            ConditionValue += Field

            If Value = "IS NOT NULL" Then
                ConditionValue += " IS NOT NULL"
            ElseIf Value = "IS NULL" Then
                ConditionValue += " IS NULL"
            Else
                ConditionValue += Space(1) + Parameter + " '" + Value + "'"
            End If

            Return Me
        End Function

        Public Function GroupBy(Field As String()) As QueryBuilder
            For Counter As Integer = 0 To Field.Length - 1
                GroupBy(Field(Counter))
            Next

            Return Me
        End Function

        Public Function GroupBy(Field As String) As QueryBuilder
            If GroupValue <> String.Empty Then
                GroupValue += ", "
            End If

            GroupValue += Field

            Return Me
        End Function

        Public Function OrderBy(Field As String, Order As String) As QueryBuilder
            If OrderValue <> String.Empty Then
                OrderValue += ", "
            End If

            OrderValue += Field + Space(1) + Order

            Return Me
        End Function

        Public Function InnerJoin(TableName As String, Parameter As String()) As QueryBuilder
            If JoinValue <> String.Empty Then
                JoinValue += Space(1)
            End If

            JoinValue += "INNER JOIN " + TableName + " ON "

            Select Case Parameter.Length
                Case 2
                    JoinValue += Parameter(0) + " = " + Parameter(1)
                Case 3
                    JoinValue += Parameter(0) + Space(1) + Parameter(1) + Space(1) + Parameter(2)
            End Select

            Return Me
        End Function

        Public Function WrapCondition() As QueryBuilder
            If ConditionValue <> String.Empty Then
                ConditionValue = "(" + ConditionValue + ")"
            End If

            Return Me
        End Function

        Public Function WrapCondition(Link As String) As QueryBuilder
            If ConditionValue <> String.Empty Then
                If Link Is Nothing Then
                    ConditionValue = "(" + ConditionValue + ") AND "
                Else
                    ConditionValue = "(" + ConditionValue + ") " + Link + Space(1)
                End If
            End If

            Return Me
        End Function

        Public Function Read() As DataTable
            If TableValue Is Nothing Then
                Return Nothing
            Else
                Dim Query As String = "SELECT"

                If FieldValue Is Nothing Then
                    Query += " *"
                Else
                    Query += Space(1) + FieldValue
                End If

                Query += " FROM " + TableValue

                If JoinValue IsNot Nothing Then
                    Query += Space(1) + JoinValue
                End If

                If ConditionValue IsNot Nothing Then
                    Query += " WHERE " + ConditionValue
                End If

                If GroupValue IsNot Nothing Then
                    Query += " GROUP BY " + GroupValue
                End If

                If OrderValue IsNot Nothing Then
                    Query += " ORDER BY " + OrderValue
                End If

                Return ExecuteDataTable(Query)
            End If
        End Function

        Public Function Create(Value As String()) As Boolean
            If TableValue Is Nothing Then
                Return False
            Else
                Dim Query As String = "INSERT INTO " + TableValue + " VALUES ("

                For Counter As Integer = 0 To Value.Count - 1
                    If Counter > 0 Then
                        Query += ", "
                    End If

                    If Value(Counter) = "NULL" Then
                        Query += "NULL"
                    Else
                        Query += "'" + Value(Counter) + "'"
                    End If
                Next

                Query += ")"

                Return ExecuteBoolean(Query)
            End If
        End Function

        Public Function Update(Value As String(,)) As Boolean
            If TableValue Is Nothing Then
                Return False
            Else
                Dim Query As String = "UPDATE " + TableValue + " SET "

                For Counter As Integer = 0 To Value.GetLength(0) - 1
                    If Counter > 0 Then
                        Query += ", "
                    End If

                    Query += Value(Counter, 0) + " = '" + Value(Counter, 1) + "'"
                Next

                If ConditionValue IsNot Nothing Then
                    Query += " WHERE " + ConditionValue
                End If

                Return ExecuteBoolean(Query)
            End If
        End Function

        Public Function Update(Field As String, Value As String) As Boolean
            If TableValue Is Nothing Then
                Return False
            Else
                Dim Query As String = "UPDATE " + TableValue + " SET " + Field + " = '" + Value + "'"

                If ConditionValue IsNot Nothing Then
                    Query += " WHERE " + ConditionValue
                End If

                Return ExecuteBoolean(Query)
            End If
        End Function

        Public Function Delete() As Boolean

            If TableValue Is Nothing Then
                Return False
            Else
                Dim Query As String = "DELETE FROM " + TableValue

                If ConditionValue IsNot Nothing Then
                    Query += " WHERE " + ConditionValue
                End If

                Return ExecuteBoolean(Query)
            End If
        End Function

        Private Function ExecuteDataTable(Query As String) As DataTable
            Try
                Dim SqlConnection As New SqlConnection(Connection)
                Dim SqlCommand As SqlCommand = SqlConnection.CreateCommand
                Dim DataTable As New DataTable

                SqlConnection.Open()

                With SqlCommand
                    .CommandTimeout = 0
                    .CommandText = Query
                End With

                With New SqlDataAdapter
                    .SelectCommand = SqlCommand

                    .Fill(DataTable)
                End With

                SqlConnection.Close()

                Return DataTable
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        Private Function ExecuteBoolean(Query As String) As Boolean
            Try
                Dim SqlConnection As New SqlConnection(Connection)
                Dim SqlCommand As SqlCommand = SqlConnection.CreateCommand

                SqlConnection.Open()

                With SqlCommand
                    .CommandTimeout = 0
                    .CommandText = Query

                    .ExecuteNonQuery()
                End With

                SqlConnection.Close()

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function
    End Class
End Namespace

