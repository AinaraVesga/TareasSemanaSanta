Imports System

Module Program

    ' ESTRUCTURAS

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


    ' ATRIBUTOS:

    ' Definimos empleados
    Public emp1 As New empleado With {.ID = 1, .NOMBRE = "PEDRO MARCOS", .DPTO = 2, .EDAD = 56, .ANIOSTRAB = 34}
    Public emp2 As New empleado With {.ID = 2, .NOMBRE = "ANA ATUTXA", .DPTO = 1, .EDAD = 23, .ANIOSTRAB = 4}

    ' Definimos los usuarios
    Public us1 As New usuario With {.ID = emp1.ID, .CONTRASEÑA = "1234"}
    Dim us2 As New usuario With {.ID = emp2.ID, .CONTRASEÑA = "HOLA"}

    ' Creamos las listas donde se almacenarán los empleados y los usuarios
    Public empleados As New List(Of empleado) From {emp1, emp2}
    Public usuarios As New List(Of usuario) From {us1, us2}


    ' FUNCIONES:

    ' Función para registrar a un nuevo empleado
    Public Sub nuevoUsuario()

        Console.WriteLine("Introduzca su identificador:")
        Dim id = Console.ReadLine
        Dim pw, pw2 As String
        Do
            Console.WriteLine("Introduzca su contraseña: ")
            pw = Console.ReadLine
            Console.WriteLine("Introduzca de nuevo su contraseña: ")
            pw2 = Console.ReadLine
        Loop Until pw = pw2
        Console.WriteLine("Introduzca su nombre completo: ")
        Dim nombre = Console.ReadLine
        Console.WriteLine("Introduzca su departamento: ")
        Dim depart = Console.ReadLine
        Console.WriteLine("Introduzca su edad: ")
        Dim edad = Console.ReadLine
        Console.WriteLine("Introduzca sus años trabajados: ")
        Dim anios = Console.ReadLine

        Dim nuevoEmpleado As New empleado With {.ID = id, .NOMBRE = nombre, .DPTO = depart, .EDAD = edad, .ANIOSTRAB = anios}
        Dim nuevoUser As New usuario With {.ID = id, .CONTRASEÑA = pw}

        empleados.Add(nuevoEmpleado)
        usuarios.Add(nuevoUser)

        Console.WriteLine("Se ha registrado correctamente.")

    End Sub

    ' Función que pide al usuario que se identifique
    Public Function login()

        ' Variable que nos hará permanecer en el ciclo
        Dim continuar = True

        ' El sistema pide al usuario que se identifique
        Do
            Console.WriteLine("Introduzca su usuario: ")
            Dim user = Console.ReadLine
            Console.WriteLine("Introduzca su contraseña: ")
            Dim pw = Console.ReadLine

            ' Comprobamos si existe el usuario
            Dim nuevo As New usuario With {.ID = user, .CONTRASEÑA = pw}

            If usuarios.IndexOf(nuevo) = -1 Then
                Console.WriteLine("Usuario o contraseña no válidos.")
                Console.WriteLine("Introduzca '1' para intentarlo de nuevo o '2' para registrarse:")
                Dim resp = Console.ReadLine

                ' Pedimos al empleado que se registre
                If resp = 2 Then
                    nuevoUsuario()
                End If

            Else
                Console.WriteLine("Se ha identificado correctamente.")
                continuar = False
            End If

        Loop While continuar

    End Function


    ' PROGRAMA PRINCIPAL:
    Sub Main(args As String())

        login()

    End Sub
End Module
