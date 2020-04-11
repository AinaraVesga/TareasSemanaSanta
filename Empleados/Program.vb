Imports System
Imports System.IO
Imports System.Text

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

    ' Función para saber si un ID está registrado en usuarios
    Public Function idRegistradoU(id As Integer)
        Dim esta = False
        Dim i = 0

        While esta = False And i < usuarios.Count
            If id = usuarios(i).ID Then
                esta = True
            Else
                i += 1
            End If
        End While

        Return esta
    End Function

    ' Función para encontrar un usuario a partir de su ID
    Public Function posIdUsuarios(id As Integer)
        Dim encontrado = False
        Dim i = 0

        If idRegistradoU(id) Then

            While encontrado = False And i < usuarios.Count
                If id = usuarios(i).ID Then
                    encontrado = True
                Else
                    i += 1
                End If
            End While
        End If

        Return i
    End Function

    ' Función para saber si un ID está registrado en empleados
    Public Function idRegistradoE(id As Integer)
        Dim esta = False
        Dim i = 0

        While esta = False And i < empleados.Count
            If id = empleados(i).ID Then
                esta = True
            Else
                i += 1
            End If
        End While

        Return esta
    End Function

    ' Función para encontrar un usuario a partir de su ID
    Public Function posIdEmpleados(id As Integer)
        Dim encontrado = False
        Dim i = 0

        If idRegistradoE(id) Then

            While encontrado = False And i < empleados.Count
                If id = empleados(i).ID Then
                    encontrado = True
                Else
                    i += 1
                End If
            End While
        End If

        Return i
    End Function

    ' Función para calcular los días de vacaciones que tiene un empleado
    Public Function vacaciones(id As Integer)
        Dim vac = 0

        If idRegistradoE(id) Then
            Dim i = posIdEmpleados(id)
            Dim trab = empleados(i).ANIOSTRAB
            Dim dpto = empleados(i).DPTO

            If trab > 2 And trab < 7 Then
                vac = 15
            ElseIf trab >= 7 Then
                If dpto = 1 Then
                    vac = 20
                ElseIf dpto = 2 Then
                    vac = 25
                ElseIf dpto = 3 Then
                    vac = 30
                End If
            End If
        End If

        Return vac
    End Function

    ' Función para calcular el sueldo de un empleado
    Public Function sueldo(id As Integer)
        Dim salary = 0
        Dim base = 1500

        If idRegistradoE(id) Then
            Dim i = posIdEmpleados(id)
            Dim edad = empleados(i).EDAD

            If edad < 18 Then
                Console.WriteLine("Con " + edad + " años no está permitido trabajar.")
            ElseIf edad >= 18 And edad <= 50 Then
                salary = base + base * 0.05
            ElseIf edad > 50 And edad <= 60 Then
                salary = base + base * 0.1
            ElseIf edad > 60 Then
                salary = base + base * 0.15
            End If

        End If

        Return salary
    End Function

    ' Función para crear un archivo de texto --> Aquí se guardaraán todos los empleados que han sido identificados
    Public Function crearFichero()
        Dim ruta As String = "C:\Users\Ainara\Documents\AA_EMPLEADOS\registroEmpleados.log"

        ' Crear o sobrescribir el archivo
        Dim fs As FileStream = File.Create(ruta)


        ' Cerramos el fichero
        fs.Close()

        ' Lo volvemos a abrir
        FileOpen(1, "C:\Users\Ainara\Documents\AA_EMPLEADOS\registroEmpleados.log", OpenMode.Output)

        ' Escribimos el encabezado
        PrintLine(1, "Fecha: " + Now)
        PrintLine(1)
        PrintLine(1)

        Dim columnas = {"|", "NOMBRE", "EDAD", "T. LABORADO", "DÍAS VAC.", "SALARIO (EUROS)"}
        Dim encabezado = String.Format("{0} {1,-30} {0} {2,-10} {0} {3,-15} {0} {4,-15} {0} {5,-15} {0}", columnas)
        PrintLine(1, encabezado)

        encabezado = String.Format(("").PadRight(100, "-"))
        PrintLine(1, encabezado)

    End Function

    ' Función para escribir en el fichero --> Para escribir en el fichero cada línea de identificación del usuario
    Public Function escribirFichero(linea As String)
        ' FileOpen(1, "C:\Users\Ainara\Documents\AA_EMPLEADOS\registroEmpleados.log", OpenMode.Output)
        PrintLine(1, linea)

    End Function

    ' Función para imprimir por pantalla y en el fichero de refistros los datos de un usuario
    Public Function datosEmpleado(id As Integer)
        'Dim id = 1
        Dim i = posIdEmpleados(id)

        Console.WriteLine(("").PadRight(100, "-"))
        Console.WriteLine("{0} {1,-30} {0} {2,-10} {0} {3,-15} {0} {4,-15} {0} {5,-15} {0}", "|", "NOMBRE", "EDAD", "T. LABORADO", "DÍAS VAC.", "SALARIO (EUROS)")
        Console.WriteLine(("").PadRight(100, "-"))

        Dim columnas = {"|", empleados(i).NOMBRE, empleados(i).EDAD, empleados(i).ANIOSTRAB, vacaciones(id), sueldo(id)}
        Dim linea = String.Format("{0} {1,-30} {0} {2,-10} {0} {3,-15} {0} {4,-15} {0} {5,-15} {0}", columnas)
        Console.WriteLine(linea)
        escribirFichero(linea)
        Console.WriteLine(("").PadRight(100, "-"))

    End Function

    ' Función para registrar a un nuevo empleado
    Public Sub nuevoUsuario()
        Dim seguir As Boolean
        Dim id As Integer
        ' Comprueba que el identificador introducido no existe dentro del registro de usuarios
        Do
            Console.WriteLine("Introduzca su identificador:")
            id = Console.ReadLine
            If idRegistradoU(id) Then
                Console.WriteLine("Ya existe un usuario registrado con el identificador " + id)
                seguir = True
            Else
                seguir = False
            End If
        Loop While seguir = True

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

        Console.WriteLine("Se ha registrado correctamente")

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
                    datosEmpleado(user)
                    continuar = False
                End If
                Return True
            End If
        Loop While continuar
    End Function


    ' PROGRAMA PRINCIPAL:
    Sub Main(args As String())
        crearFichero()
        ' Llamamos en cada ciclo a la función login para identificar los usuarios
        Dim seguir As Boolean
        Do
            seguir = login()
        Loop While seguir

        FileClose()
    End Sub
End Module
