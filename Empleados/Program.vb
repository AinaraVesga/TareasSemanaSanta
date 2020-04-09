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

    ' Estructura para almacenar los diferentes departamentos de la empresa
    Public Structure departamento
        Public IDDEP As Integer
        Public NOMBREDEP As String
    End Structure


    ' ATRIBUTOS:

    ' Definimos empleados
    Public emp1 As New empleado With {.ID = 1, .NOMBRE = "PEDRO MARCOS", .DPTO = 2, .EDAD = 56, .ANIOSTRAB = 34}
    Public emp2 As New empleado With {.ID = 2, .NOMBRE = "ANA ATUTXA", .DPTO = 1, .EDAD = 23, .ANIOSTRAB = 4}

    ' Definimos los usuarios
    Public us1 As New usuario With {.ID = emp1.ID, .CONTRASEÑA = "1234"}
    Public us2 As New usuario With {.ID = emp2.ID, .CONTRASEÑA = "HOLA"}

    ' Definimos los departamentos de la empresa
    Public dep1 As New departamento With {.IDDEP = 1, .NOMBREDEP = "ATENCIÓN AL CLIENTE"}
    Public dep2 As New departamento With {.IDDEP = 2, .NOMBREDEP = "LOGÍSTICA"}
    Public dep3 As New departamento With {.IDDEP = 3, .NOMBREDEP = "GERENCIA"}

    ' Creamos las listas donde se almacenarán los empleados y los usuarios
    Public empleados As New List(Of empleado) From {emp1, emp2}
    Public usuarios As New List(Of usuario) From {us1, us2}
    Public departamentos As New List(Of departamento) From {dep1, dep2, dep3}


    ' FUNCIONES:

    ' Función para registrar a un nuevo empleado
    Public Sub nuevoUsuario()
        Dim seguir As Boolean
        Dim id As Integer
        ' Comprueba que el identificador introducido no existe dentro del registro de usuarios
        Do
            Console.WriteLine("Introduzca su identificador:")
            id = Console.ReadLine
            Dim i = 0
            seguir = True
            Do
                If id = usuarios(i).ID Then
                    Console.WriteLine("Ya existe un usuario con este ID.")
                    seguir = False
                Else
                    i += 1
                End If
            Loop While seguir And i < usuarios.Count
        Loop While seguir = False

        ' Comprueba que las contraseñas coinciden
        Dim pw, pw2 As String
        Do
            Console.WriteLine("Introduzca su contraseña: ")
            pw = Console.ReadLine
            Console.WriteLine("Introduzca de nuevo su contraseña: ")
            pw2 = Console.ReadLine
            If pw <> pw2 Then
                Console.WriteLine("Las contraseñas no coinciden.")
            End If
        Loop Until pw = pw2
        Console.WriteLine("Introduzca su nombre completo: ")
        Dim nombre = Console.ReadLine

        ' Comprueba que el departamento introducido coincide con alguno registrado
        Dim depart As Integer
        Do
            Console.WriteLine("Introduzca su departamento: ")
            depart = Console.ReadLine
            Dim i = 0
            seguir = True
            Do
                If depart = departamentos(i).IDDEP Then
                    seguir = False
                Else
                    i += 1
                End If
            Loop While seguir And i < departamentos.Count
            If seguir Then
                Console.WriteLine("No existe el departamento introducido.")
            Else
                Console.WriteLine("Pertenece al departamento: " + departamentos(i).NOMBREDEP)
            End If
        Loop While seguir

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

            ' Si el usuario = 0 se para el programa
            If user = 0 Then
                Return False
            Else
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
                Return True
            End If
        Loop While continuar
    End Function

    ' Función para calcular los días de vacaciones que pertenecen a un empleado
    Public Function vacaciones()

    End Function

    ' Función para calcular el sueldo de un empleado
    Public Function sueldo()

    End Function

    ' Función para imprimir por pantalla los datos de un usuario
    Public Function datosEmpleado()

    End Function

    ' PROGRAMA PRINCIPAL:
    Sub Main(args As String())

        ' Llamamos en cada ciclo a la función login para identificar los usuarios
        Dim seguir As Boolean
        Do
            seguir = login()
        Loop While seguir

    End Sub
End Module
