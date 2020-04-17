Imports System

Module Program

    Dim width As Integer
    Dim height As Integer
    Dim limH As Integer
    Dim limW As Integer


    Public Function contorno(area As String(,))

        For i = 0 To limH
            For j = 0 To limW
                If j = 0 And i = limH Then
                    area(i, j) = "|_"
                ElseIf j = 0 And i > 0 Then
                    area(i, j) = "| "
                ElseIf i = 0 And j < limW Or i = limH And j < limW Then
                    area(i, j) = " _"
                ElseIf j = limW And i > 0 Then
                    area(i, j) = "| "
                Else
                    area(i, j) = "  "
                End If
            Next
        Next

        Return area

    End Function

    Public Function añadirColumna(w0 As Integer, h0 As Integer, area As String(,))

        For i = h0 + 1 To limH
            If i = limH Then
                area(i, w0) = "|_"
            Else
                area(i, w0) = "| "
            End If
        Next

        Return area

    End Function

    Public Function añadirFila(w0 As Integer, h0 As Integer, area As String(,))

        For j = w0 To limW - 1
            If j = w0 Then
                area(h0, j) = "|_"
            Else
                area(h0, j) = " _"
            End If
        Next

        Return area

    End Function

    Sub Main(args As String())


        ' Variables
        Dim impar As Boolean = True

        ' Pedimos una lista de números
        Dim lista = New List(Of Integer)
        Dim num As Integer
        Console.WriteLine("Introduzca todos los número que quiera. Para parar, introduzca 0 o un número negativo.")
        Do
            Console.WriteLine("Introduzca un número positivo:")
            num = Console.ReadLine
            If num > 0 Then
                lista.Add(num)
            End If
        Loop While num > 0

        ' Pedimos las dimensiones del rectángulo
        Console.WriteLine()
        Console.WriteLine("Introduzca las dimensiones del rectángulo.")
        Console.WriteLine("Ancho: ")
        width = Console.ReadLine
        Console.WriteLine("Alto: ")
        height = Console.ReadLine

        ' Calculamos proporcion del rectángulo
        limH = height / 10
        limW = width / 10

        ' Creamos el area del rectangulo
        Dim area(limH, limW) As String

        ' Representamos el contorno del cuadrado
        area = contorno(area)

        ' Ordenamos la lista de mayor a menor
        lista.Sort()
        lista.Reverse()
        Dim h0 As Integer = 0
        Dim w0 As Integer = 0


        Do
            ' Se suman todos los números de la lista
            Dim total As Integer = lista.Sum
            ' Sacamos el primer elemento de la lista
            Dim mayor As Integer = lista(0)
            lista.RemoveAt(0)

            If impar Then
                w0 = w0 + mayor * (limW - w0) / total
                area = añadirColumna(w0, h0, area)
                impar = False
            Else
                h0 = h0 + mayor * (limH - h0) / total
                area = añadirFila(w0, h0, area)
                impar = True
            End If

        Loop While lista.Count > 1

        ' Mostrar el dibujo
        For i As Integer = 0 To limH
            For j As Integer = 0 To limW
                Console.Write(area(i, j))
            Next
            Console.WriteLine()
        Next

    End Sub


End Module
