Imports System

Module Program
    ' Estructura para almacenar datos de los empleados
    Public Structure empleado
        Public ID As Integer
        Public NOMBRE As String
        Public DPTO As Integer
        Public EDAD As Integer
        Public ANIOSTRAB As Integer
    End Structure

    ' Estructura para almacenar los usuarios del sistema
    Public Structure usuario
        Public ID As Integer
        Public CONTRASEÑA As String
    End Structure


    Sub Main(args As String())

        ' Creamos las listas donde se almacenarán los empleados y los usuarios
        Dim empleados As New List(Of empleado)
        Dim usuarios As New List(Of usuario)

        ' Definimos empleados
        Dim emp1 As New empleado With {.ID = 1, .NOMBRE = "PEDRO MARCOS", .DPTO = 2, .EDAD = 56, .ANIOSTRAB = 34}
        Dim emp2 As New empleado With {.ID = 2, .NOMBRE = "ANA ATUTXA", .DPTO = 1, .EDAD = 23, .ANIOSTRAB = 4}

        ' Añadimos los empleados a la lista de empleados
        empleados.Add(emp1)
        empleados.Add(emp2)

        ' Definimos los usuarios
        Dim us1 As New usuario With {.ID = emp1.ID, .CONTRASEÑA = "1234"}
        Dim us2 As New usuario With {.ID = emp2.ID, .CONTRASEÑA = "HOLA"}

        ' Añadimos los usuarios a la lista de usuarios
        usuarios.Add(us1)
        usuarios.Add(us2)

        Console.WriteLine(empleados.Count)
        Console.WriteLine(usuarios.Count)

    End Sub
End Module
