import random, tkinter


gameWindow = tkinter.Tk()
gameWindow.geometry("500x400")
gameWindow.title("Pedra Papel Tesoura")



itensList = ["Pedra", "Papel", "Tesoura"]

def escolher_mao(mao):
    global maoPlayer
    maoPlayer = mao

def EscolherMão():

    maoIA = random.randrange(1,4)
    maoIA = itensList[maoIA - 1]

    resultado_texto = tkinter.StringVar()
    resultado = tkinter.Label(gameWindow, textvariable=resultado_texto)
    resultado.pack()
    resultado.place(x=200, y=300)

    opcaoPlayer = tkinter.Label(gameWindow, text="Escolha sua mão: ")
    opcaoPlayer.pack()
    opcaoPlayer.configure(font=15)
    opcaoPlayer.place(x=100, y=70)


    btnPedra = tkinter.Button(gameWindow, text="Pedra", command=lambda: escolher_mao(itensList[0]), width=10, height=5)
    btnPedra.pack()
    btnPedra.place(x=100, y=100)

    
    btnPapel = tkinter.Button(gameWindow,text="Papel", command= lambda:  escolher_mao(itensList[1]), width=10, height=5)
    btnPapel.pack()
    btnPapel.place(x=200, y=100)

    btnTesoura = tkinter.Button(gameWindow,text="Tesoura", command= lambda:  escolher_mao(itensList[2]),width=10, height=5)
    btnTesoura.pack()
    btnTesoura.place(x=300, y=100)


    
    def validarGame():
        maoIA = random.choice(itensList)
        result = f"\nMão do jogador: {maoPlayer}, e da IA foi: {maoIA}"
        resultado_texto.set(result)

        if maoIA == "Pedra" and maoPlayer == "Tesoura":
            result = " IA ganhou!"
        elif maoIA == "Tesoura" and maoPlayer == "Papel":
            result = " IA ganhou!"
        elif maoIA == "Papel" and maoPlayer == "Pedra":
            result = " IA ganhou!"
        elif maoPlayer == "Pedra" and maoIA == "Tesoura":
            result = " Você ganhou!"
        elif maoPlayer == "Tesoura" and maoIA == "Papel":
            result = " Você ganhou!"
        elif maoPlayer == "Papel" and maoIA == "Pedra":
            result = " Você ganhou!"
        elif maoIA == maoPlayer:
            result = " Empate"
            EscolherMão()

        resultado_texto.set(result)

    
    btnPlay = tkinter.Button(gameWindow, text="Estou Pronto!", command=validarGame)
    btnPlay.pack()
    btnPlay.place(x=200, y=200)

EscolherMão()
gameWindow.mainloop()


