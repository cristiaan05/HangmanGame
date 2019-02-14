Public Class Form1
    Private Sub Reiniciar()
        Me.Refresh()
    End Sub
    Dim cafe As New Pen(Brushes.Brown)
    Dim negro As New Pen(Brushes.Black)
    Dim etiqueta As Label
    Dim cantidad, cont, posetiqueta As Integer
    Dim correctas As Integer
    Dim intentos As Integer = 0
    Dim palabra, letra, usadas As String
    Dim palabras(15) As String
    Dim pistas(15) As String

    Private Sub NuevoToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles NuevoToolStripMenuItem1.Click
        Application.Restart()
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtLetra.Enabled = False
        btnIntentar.Enabled = False
        lblRestantes.Text = "8"
        palabras(0) = "hola"
        palabras(1) = "temblor"
        palabras(2) = "juniorexpress"
        palabras(3) = "murcielago"
        palabras(4) = "antigua"
        palabras(5) = "crema"
        palabras(6) = "computadora"
        palabras(7) = "mono"
        palabras(8) = "arbol"
        palabras(9) = "manzana"
        palabras(10) = "autobus"
        palabras(11) = "mochila"
        palabras(12) = "reloj"
        palabras(13) = "gorra"
        palabras(14) = "barco"

        pistas(0) = "Saludo"
        pistas(1) = "Moviento violento de las placas tectonicas"
        pistas(2) = "Programa infantil de Disney Junior"
        pistas(3) = "Animal mamífero de hábitos nocturnos, son alados y cuentan con la particularidad de dormir cabeza abajo"
        pistas(4) = "Ciudad de guatemala tambien llamada Santiago de los Caballeros"
        pistas(5) = "Sustancia alimenticia de consistencia más o menos pastosa"
        pistas(6) = "Máquina electrónica capaz de almacenar información y tratarla automáticamente mediante operaciones matemáticas y lógicas."
        pistas(7) = "Primates del suborden de los antropoides "
        pistas(8) = "Planta de tronco leñoso, grueso y elevado que se ramifica a cierta altura del suelo formando la copa."
        pistas(9) = "Fruto comestible, de forma redondeada y algo hundida por los extremos,puede ser roja,verde o amarilla"
        pistas(10) = "Vehículo automóvil con capacidad para gran número de viajeros, destinado al transporte de pasajeros por carretera."
        pistas(11) = "Bolsa para transportar provisiones en excursiones, viajes u otro tipo de desplazamientos."
        pistas(12) = "Instrumento para medir el tiempo."
        pistas(13) = "Prenda de vestir de forma redonda y lleva una visera."
        pistas(14) = "Embarcación con el fondo cóncavo y con cubierta."
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnIntentar.Click
        Dim dibujar As Graphics = PictureBox1.CreateGraphics
        cafe.Width = 8.0F
        negro.Width = 2.2F
        Dim arreglo() = palabra.ToCharArray
        usadas = usadas & " " & letra
        letra = txtLetra.Text
        If usadas.Contains(letra) Then
            MessageBox.Show("Ya ingresaste esa letra,ingresa otra")
            intentos = intentos - 1
        Else
            lblUsadas.Text = usadas & " " & letra
        End If
        posetiqueta = 50
        For x As Integer = 0 To palabra.Length - 1
            If arreglo(x) = letra Then
                etiqueta = New Label()
                etiqueta.Text = letra
                etiqueta.Width = 50
                etiqueta.Location = New Point(posetiqueta, 350)
                Me.Controls.Add(etiqueta)
                correctas += 1
            End If
            posetiqueta += 55
        Next
        If correctas = palabra.Length Then
            Me.AxWindowsMediaPlayer2.URL = "C:\Users\informatica\Desktop\Ahorcado\winner.mp3"
            ' My.Computer.Audio.Play = (My.Resources.fondo.)
            Dim result As Integer = MessageBox.Show("¿Desea jugar de nuevo?", "¡¡Ganaste!! :)", MessageBoxButtons.YesNo)
            If result = DialogResult.No Then
                Application.Exit()
            ElseIf result = DialogResult.Yes Then
                Application.Restart()
            End If
        End If
        If Not palabra.Contains(letra) Then
            intentos = intentos + 1
            Select Case intentos
                Case 1
                    dibujar.DrawLine(cafe, 0, 310, 80, 310)
                    dibujar.DrawLine(cafe, 0, 10, 0, 310)
                    dibujar.DrawLine(cafe, 0, 10, 100, 10)
                    dibujar.DrawLine(cafe, 100, 10, 100, 50)
                Case 2
                    dibujar.DrawEllipse(negro, 75, 50, 50, 50)
                    dibujar.DrawLine(negro, 90, 70, 90, 75)
                    dibujar.DrawLine(negro, 110, 70, 110, 75)
                    dibujar.DrawLine(negro, 90, 90, 110, 90)
                Case 3
                    dibujar.DrawLine(negro, 100, 100, 100, 240)
                Case 4
                    dibujar.DrawLine(negro, 100, 150, 50, 130)
                Case 5
                    dibujar.DrawLine(negro, 100, 150, 150, 130)
                Case 6
                    dibujar.DrawLine(negro, 100, 240, 80, 280)
                Case 7
                    dibujar.DrawLine(negro, 100, 240, 120, 280)
                Case 8
                    Me.AxWindowsMediaPlayer1.URL = "C:\Users\informatica\Desktop\Ahorcado\loser.mp3"
                    Dim result As Integer = MessageBox.Show("¿Desea jugar de nuevo?", "Haz Perdido... :(", MessageBoxButtons.YesNo)
                    If result = DialogResult.No Then
                        Application.Exit()
                    ElseIf result = DialogResult.Yes Then
                        Application.Restart()
                    End If
            End Select
        End If
        lblRestantes.Text = CStr(8 - intentos)
        txtLetra.Clear()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnIniciar.Click
        'generar palabra aleatoria
        Dim nPista As Integer
        Randomize()
        nPista = 14 * Rnd()
        palabra = palabras(nPista)
        rhTxtPista.Text = pistas(nPista)

        'generar etiquetas   
        cantidad = Len(palabra)
        posetiqueta = 50

        For cont = 1 To cantidad Step 1
            etiqueta = New Label()
            etiqueta.Text = "__"
            etiqueta.Width = 50
            etiqueta.Location = New Point(posetiqueta, 370)
            Me.Controls.Add(etiqueta)
            posetiqueta += 55
        Next
        btnIniciar.Enabled = False
        btnIntentar.Enabled = True
        txtLetra.Enabled = True
    End Sub
End Class
