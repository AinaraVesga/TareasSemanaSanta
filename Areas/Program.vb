Imports System

Module Program

    Public Function contorno(width As Integer, height As Integer)

        Dim w As Integer = width / 10
        Dim h As Integer = height / 10

        Console.WriteLine($"{w} {h}")

        Dim arriba = New List(Of String)
        For i As Integer = 0 To w
            If i = w Then
                arriba.Add("  ")
            Else
                arriba.Add(" _")
            End If
        Next

        Dim medio = New List(Of String)
        For i As Integer = 0 To w
            If i = 0 Or i = w Then
                medio.Add("| ")
            Else
                medio.Add("  ")
            End If
        Next

        Dim abajo = New List(Of String)
        For i As Integer = 0 To w
            If i = 0 Then
                abajo.Add("|_")
            ElseIf i = w Then
                abajo.Add("|")
            Else
                abajo.Add(" _")
            End If
        Next

        Dim area = New List(Of List(Of String))
        area.Add(arriba)
        For i As Integer = 0 To h - 2
            area.Add(medio)
        Next
        area.Add(abajo)

        ' Mostrar el dibujo
        For i As Integer = 0 To h
            For j As Integer = 0 To w
                Console.Write(area(i)(j))
            Next
            Console.WriteLine()
        Next

        Return area

    End Function

    Public Function añadirColumna(w As Integer, h As Integer, width As Integer, height As Integer, area As List(Of List(Of String)))
        For i = h + 1 To height - 2
            Console.WriteLine(i)
            If i = height Then
                area(i)(w) = "|_"
            Else
                area(i)(w) = "| "
            End If
        Next

        Return area
    End Function

    Public Function añadirFila(w As Integer, h As Integer, width As Integer, height As Integer, area As List(Of List(Of String)))
        For j = w To width - 1
            If j = w Then
                area(h)(j) = "|_"
            Else
                area(h)(j) = " _"
            End If
        Next

        Return area
    End Function

    Sub Main(args As String())

        ' Variables
        Dim par As Boolean = False

        ' Ordenamos la lista de mayor a menor
        Dim lista = New List(Of Integer) From {1, 4, 2, 7, 5}
        Dim width = 100
        Dim height = 100
        Dim h0 As Integer = 10
        Dim w0 As Integer = 10
        Dim area = contorno(width, height)
        lista.Sort()
        lista.Reverse()

        Dim w1 As Integer = 0
        Dim h1 As Integer = 0

        Do
            ' Se suman todos los números de la lista
            Dim total As Integer = lista.Sum
            ' Sacamos el primer elemento de la lista
            Dim mayor As Integer = lista(0)
            lista.RemoveAt(0)
            ' Se suman los números restantes de la lista
            Dim resto As Integer = lista.Sum

            If par Then ' Cuando par es true: se reparten la altura
                h1 = mayor * h0 / total
                añadirFila(w0, h1, width, height, area)
                h0 = h1
                par = False

            Else ' Cuando par es false: se reparten la anchura
                w1 = mayor * w0 / total
                añadirColumna(w1, h0, width, height, area)
                w0 = w1
                par = True

            End If

            ' Mostrar el dibujo
            For i As Integer = 0 To h0
                For j As Integer = 0 To w0
                    Console.Write(area(i)(j))
                Next
                Console.WriteLine()
            Next

        Loop While lista.Count > 1



        For Each num As Integer In lista
            Console.Write($"{num} - ")
        Next

    End Sub

End Module
