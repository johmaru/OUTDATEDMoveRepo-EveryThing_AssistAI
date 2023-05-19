
import os
import json
from bardapi import Bard

if os.path.exists('token.json') :
    pass
else :
    check_token = {'token': '1PSID'}
    with open('token.json', 'w') as f:
     json.dump(check_token, f)
     print('token.json created plz edit it file. file location is RootDirectory/token.json\r\n')

while True:
    with open('token.json') as f:
     data = json.load(f)
    Btoken = data['token']
    try:
        bard = Bard(token=Btoken)
    except :
        print('token is not correct plz check token.json file\r\n')
        exit()
    try:
         print('if you want end talk please input exit_app\r\n')
         input_text = input('please input anything\r\n')
         print()
         if input_text == 'exit_app' :
             print('terminate the application.\r\n')
             exit()
         else :
          answer = bard.get_answer(input_text)
          print()
          print(answer['content'])
          print()
         continue
    except Exception as e :
        print('Sorry, there was an unexplained error. Terminate the application.\r\n')
        print(e)
        exit()
