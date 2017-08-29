"""
A State Quarter console application done in python
with the use of sqlite
"""
import sys
import dataLayer as db
import quarter as q
import state as s


def showGreeting():
    print "Welcome to the State Quarter App"
    print "Choose from the options below to continue...\n"
    
def showMainOptions():
    print "1)Select Quarter by Year Issued"
    print "2)Select Quarter by State"
    print "3)Check Quarters Collected"
    print "4)Exit or Quit"

stateList = ('ALABAMA', 'ALASKA', 'ARIZONA', 'ARKANSAS', 'CALIFORNIA', 'COLORADO', 'CONNECTICUT', 'DELAWARE', 'FLORIDA', 'GEORGIA', 'HAWAII', 'IDAHO', 'ILLINOIS', 'INDIANA', 'IOWA', 'KANSAS',
'KENTUCKY', 'LOUISIANA', 'MAINE', 'MARYLAND', 'MASSACHUSETTS', 'MICHIGAN', 'MINNESOTA', 'MISSISSIPPI', 'MISSOURI', 'MONTANA', 'NEBRASKA', 'NEVADA', 'NEW JERSEY', 'NEW MEXICO', 
'NEW YORK', 'NEW HAMPSHIRE', 'NORTH CAROLINA', 'NORTH DAKOTA', 'OHIO', 'OKLAHOMA', 'OREGON', 'PENNSYLVANIA', 'RHODE ISLAND', 'SOUTH CAROLINA', 'SOUTH DAKOTA', 'TENNESSEE', 'TEXAS', 'UTAH',
 'VERMONT', 'VIRGINIA', 'WASHINGTON', 'WEST VIRGINIA', 'WISCONSIN', 'WYOMING')  

stateAbr = ('AK', 'AL', 'AR', 'AZ', 'CA', 'CO', 'CT', 'DE', 'FL', 'GA', 'HI', 'IA', 'ID', 'IL', 'IN', 'KS', 'KY', 
'LA', 'MA', 'MD', 'ME', 'MI', 'MN', 'MO', 'MS', 'MT', 'NC', 'ND', 'NE', 'NH', 'NJ', 'NM', 'NV', 'OH', 
'OK', 'OR', 'PA', 'PA', 'RI', 'SC', 'SD', 'TN', 'TX', 'UT', 'VA', 'VT', 'WA', 'WI', 'WV', 'WY')
    
def showSubOption(choice):
    while(True):
        if choice == '1':
            showYearsIssued()
            break
        elif choice == '2':
            showStateOptions()
            break
        elif choice == '3':
            showCollection()
            break
        elif choice == '4':
            print "Exited"
            sys.exit()
        else:
            print "Valid Options are #s 1-4"
            choice = getUserInput()

def showYearsIssued():
    print "Enter a Year [1999-2008]"
    userInput = getUserInput()
    while(True):
        if userInput.isdigit():
            userInput = int(userInput)
            if userInput > 1998 and userInput < 2009:                                                                
                break
            else:
                print "Valid Options are Years 1999-2008"
                userInput = getUserInput()
        else:
            print "Invalid Year"
            userInput = getUserInput()
    q.showQuarterList(userInput)
    showStateOptions()

def showStateOptions():
    print "Enter a State name or abbreviation"
    userInput = getUserInput()
    while(True):
        if userInput.isdigit():
            userInput = int(userInput)
            if userInput > 0 and userInput < 51:                                                
                break
            else:
                print "Valid Options are #s 1-50"
                userInput = getUserInput()
        elif userInput.upper() in stateList or userInput.upper() in stateAbr:            
            userInput = userInput.upper()
            break
        else:
            print "Invalid State Name or Abbreviation"
            userInput = getUserInput()            
    coin = q.Quarter(userInput)    
    coin.showInformation()
    choice = q.showOptions()
    while(True):
        if choice == '1':            
            state = s.State(coin.stateName)
            state.showInformation()
            s.showOptions()
            break
        elif choice == '2':
            if coin.isCollected:
                print "Remove from Collection? (y/n)"
            else:
                print "Add to Collection? (y/n)"
            userInput = getUserInput().upper()
            if userInput.lower() == 'y' or userInput.lower() == 'yes':
                coin.updateCollectionStatus()
                showCollection()
                break
            else:
                print "Update canceled..."
                choice = q.showOptions()
                
        elif choice == '3':                                    
            break
        else:
            print "Valid Options are #s 1-3"
            choice = getUserInput()
    
def showCollection():
    q.showQuarterCollection(stateList)
    print "\nPress Enter to continue..."        
    userInput = raw_input()

        
def getUserInput():
    return raw_input("> ")
    


"""
The Main Program Loop
"""

while(True):
    showGreeting()
    showMainOptions()
    userInput = getUserInput()
    showSubOption(userInput)
    
"""
End Main Program Loop
"""