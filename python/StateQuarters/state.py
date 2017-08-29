import dataLayer as db

class State:
    def __init__(self, stateName):
        data = self._getStateData(stateName)        
        self.id = data["Id"]
        self.stateHood = data["StateHoodYear"] 
        self.stateName = data["StateName"]
        self.capital = data["Capital"]
        self.nickName = data["NickName"]                     
        
    def showInformation(self):
        print "\n" + self.stateName
        print self.nickName
        suf = ""
        if self.id == 1:
            suf = "st"
        elif self.id == 2:
            suf = "nd"
        else:
            suf = "th"
        print "Capital: %s" % (self.capital)  
        print "Statehood: The %s%s,  %s" % (self.id,suf,self.stateHood)
    
    def _getStateData(self, stateName):        
        return db.getStateByName(stateName)
        
def showOptions():
        print "\nPress Enter to continue..."        
        userInput = raw_input()
           