import dataLayer as db

class Quarter:
    isCollected = 0
    
    def __init__(self, selection):        
        data = self._getQuarterData(selection)                
        self.yearIssued = data["IssueYear"]
        self.stateName = data["StateName"]
        self.remarks = data["Remarks"]
        self.isCollected = data["isCollected"]
        
        
    def showInformation(self):
        print "=============================="
        print "\n%s State Quarter" % (self.stateName)
        print "Year Issued: %s" % (self.yearIssued)
        if self.isCollected:
            print "Quarter Collected: Yes"
        else:
            print "Quarter Collected: No"
        print "Remarks on Quarter"
        if self.remarks == "None" or self.remarks == "":
            print "-NONE"      
        else:
            remarks = self.remarks.split(",")
            for r in remarks:                
                print "-" + r
    
    def _getQuarterData(self, selection):        
        if type(selection) == int:
            return db.getQuarterByID(selection)
        else:            
            return db.getQuarterByName(selection)
            
    def updateCollectionStatus(self):
        if self.isCollected:
            print db.updateQuarterCollectionStatus(self.stateName, 0)
        else:
            print db.updateQuarterCollectionStatus(self.stateName, 1)

def showQuarterList(year):
    data = db.getIssueYearStateList(year)    
    stateList = "| "
    for state in data:      
        stateList += state[0] + " | "    
    print stateList

def showQuarterCollection(quarters):
    data = db.getCollectionList()
    
    if data == None or len(data) == 0:
        print "\nYour Quarter Collection"
        print "Total Collected: 0/50"
        print "Missing ALL Quarters"
    else:
        qNum = len(data)
        cList = []
        for state in data:
            cList.append(state[0])
        sorted(cList)
        
        print "\nYour Quarter Collection"
        print "Total Collected: %s/50" % qNum
        print "Collected Quarters"
        stateList = "| "
        for state in cList:
            stateList += state + " | "    
        print stateList
        
        print "\nMissing Quarters"    
        qList = [state for state in quarters if state not in cList]
        stateList = "| "
        for state in qList:
            stateList += state + " | "    
        print stateList
        
        if qNum >= 50:            
            print "\nYou are the USA State Quarter Completionist"
        elif qNum >= 25:
            print "\nCollected Over HALF"
        else:
            print "\nEnjoy building up your Collection"
            

def showOptions():
    print "\n1)View more State Information"
    print "2)Update Collection Status"
    print "3)Back to Main Menu..."
    return raw_input("> ")