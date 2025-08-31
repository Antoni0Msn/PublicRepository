import random

itensList = ["Pedra", "Papel", "Tesoura"]


def EscolherMão():
    print("\n1 - Pedra \n2 - Papel \n3 - Tesoura")
    maoPlayer = input("Escolha a mão:").strip()
    try:
        maoPlayer = int(maoPlayer)
        if maoPlayer not in [1, 2, 3]:
            print("Valor incorreto! Escolha 1, 2 ou 3.")
            return EscolherMão()
    except ValueError:
        print("Valor incorreto! Digite um número válido.")
        return EscolherMão()
    
    maoPlayer = itensList[maoPlayer - 1]
    maoIA = random.randrange(1,4)
    maoIA = itensList[maoIA - 1]
    print(f"\nMão do jogador {maoPlayer}, e da IA foi: {maoIA}")
    if(maoIA == "Pedra" and maoPlayer == "Tesoura"):
        print("IA ganhou!")
    if(maoIA == "Tesoura" and maoPlayer == "Papel"):
        print("IA ganhou!")
    if(maoIA == "Papel" and maoPlayer == "Pedra"):
        print("IA ganhou!")
        

    if(maoPlayer == "Pedra" and maoIA == "Tesoura"):
        print("Você ganhou!")
    if(maoPlayer == "Tesoura" and maoIA == "Papel"):
        print("Você ganhou!")
    if(maoPlayer == "Papel" and maoIA == "Pedra"):
        print("Você ganhou!")
    if(maoIA == maoPlayer):
        print("Empate")
        EscolherMão()

    JogarNovamente = input(f"Deseja jogar mais uma[S/N]? ").upper().strip()
    if(JogarNovamente == "S" or JogarNovamente == "Y"):
        EscolherMão()

    else:
        exit
    

EscolherMão()