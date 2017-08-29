import sqlite3 as lite
import sys



    
def getQuarterByID(selection):
    id = int(selection)
    con = lite.connect('coins.db')
    with con:
        con.row_factory = lite.Row
        cur = con.cursor()
        cur.execute("""SELECT Q.IssueYear, Q.StateName, Q.Remarks, Q.isCollected FROM Quarters AS Q
                       JOIN States AS S ON Q.StateName = S.StateName
                       WHERE S.Id=:id""", {"id":id})
        data = cur.fetchone()
        return data
    
def getQuarterByName(selection):            
    con = lite.connect('coins.db')
    with con:
        con.row_factory = lite.Row
        cur = con.cursor()
        cur.execute("""SELECT Q.IssueYear, Q.StateName, Q.Remarks, Q.isCollected FROM Quarters AS Q
                       JOIN States AS S ON Q.StateName = S.StateName
                       WHERE S.StateName=:sName OR S.PostalCode=:sName""", {"sName":selection})
        data = cur.fetchone()        
        return data
    
def getStateByID(selection):
    id = int(selection)
    con = lite.connect('coins.db')
    with con:
        con.row_factory = lite.Row
        cur = con.cursor()
        cur.execute("SELECT * FROM States WHERE Id=:Id",{"Id":id})
        data = cur.fetchone()
        return data;

def getStateByName(selection):
    con = lite.connect('coins.db')
    with con:
        con.row_factory = lite.Row
        cur = con.cursor()
        cur.execute("SELECT * FROM States WHERE StateName=:sName OR PostalCode=:sName",{"sName":selection})
        data = cur.fetchone()
        return data

    
def getIssueYearStateList(selection):
    year = int(selection)
    con = lite.connect('coins.db')
    with con:
        cur = con.cursor()
        cur.execute("SELECT StateName FROM Quarters WHERE IssueYear=:Year", {"Year":year})
        data = cur.fetchall()
        return data        
    
def getCollectionList():
    con = lite.connect('coins.db')
    with con:        
        cur = con.cursor()
        cur.execute("SELECT StateName FROM Quarters WHERE isCollected=1")
        data = cur.fetchall()
        return data

def updateQuarterCollectionStatus(selection, collectionStatus):
    con = lite.connect('coins.db')
    with con:
        con.row_factory = lite.Row
        cur = con.cursor()
        cur.execute("UPDATE Quarters SET isCollected=:isClctd WHERE StateName=:sName", {"isClctd":collectionStatus, "sName":selection})
        con.commit()
        if collectionStatus:
            return selection + " Quarter Added"
        else:
            return selection + " Quarter Removed"

#con.row_factory = lite.Row