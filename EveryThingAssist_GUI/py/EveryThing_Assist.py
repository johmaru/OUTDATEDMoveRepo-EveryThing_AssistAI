import ctypes
import sys
import os
import json
from bardapi import Bard
sys.path.insert(0, os.path.dirname(os.path.dirname(os.path.abspath(__file__))))
from Commands import help

token_path = os.path.join(os.path.dirname(sys.executable), 'token.json')

if os.path.exists(token_path):
    pass
else:
    check_token = {'token': '1PSID'}
    with open(token_path, 'w') as f:
        json.dump(check_token, f)
        print(f'token.json created plz edit it file. file location is {token_path}\r\n')
        input("Press Enter to continue...")
        exit()

while True:
    with open(token_path) as f:
        data = json.load(f)
    api_token = data['token']
    try:
        bard = Bard(token=api_token)
    except Exception as e:
        print('token is not correct plz check token.json file\r\n')
        if "SNlM0e value not found" in str(e):
            print("Err SNlM0e: ", e)
            ctypes.windll.user32.MessageBoxW(0, "Err SNlM0e: When this error occurs, BardAI recognizes that your one "
                                                "PSID is running on multiple computers and suspends Token.\r"
                                                "\rFIX Solution:"
                                                " Start your browser in private mode and log in to BardAI to retrieve "
                                                "your 1PSID.", 1)
            input("Press Enter to continue...")
            break
            exit()
        else:
            print("An unexpected error has occurred: ", e)
            input("Press Enter to continue...")
            break
            exit()
    try:
        print('if you want end talk please input exit_app\r\nplease input anything\r\n')
        input_text = input(':')
        print()
        if input_text == 'exit_app':
            print('terminate the application.\r\n')
            exit()
        elif input_text == '- help':
            help.receive_command()
            continue
        elif input_text == '- h':
            help.receive_command()
            continue
        elif input_text == '':
            print('plz any text input\r\n')
            continue
        else:
            answer = bard.get_answer(input_text)
            print()
            print(answer['content'])
            print()
        continue

    except Exception as e:
        print('Sorry, there was an unexplained error. Terminate the application.\r\n')
        print(e)
        input()
        break
        exit()
