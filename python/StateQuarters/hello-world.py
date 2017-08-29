from sys import argv

script, user_name = argv
prompt = ' > '

print "Hi %s, I'm the %s script." % (user_name, script)
print "I'd like to ask you a few questions."
print "Do you like me %s?" % user_name
lives = raw_input (prompt)

print "Where do you live %s?" % user_name
lives = raw_input (prompt)

print "What kind of computer do you have?"
computer = raw_input (prompt)
   
print """
Alright, so you said %r about liking me.
You live in %r. Not sure where that is.
And you have %r computer. Nice.
""" % (likes, lives, computer)


# this is the simplest python program
print "Hello world from Cloud9!"
# click the 'Run' button at the top to start this application