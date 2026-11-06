from time import sleep
from random import randint
import mons as mons
import sd

_pl_data = {}

def init():
	 if(sd.sdCheck()):
	 	_pl_data = sd.sdRead()
	 else:
	 	sd.sdCreate()
	 	_pl_data = {
	 		"hpm" : 100,
	 		"hp" : 100,
	 		"def" : 0,
	 		"dam" : 0,
	 		"iceW" : 0,
	 		"waterW" : 0,
	 		"fireW" : 0,
	 		"thunderW" : 0,
	 		"rayW" : 0,
	 		"inv" : {},

	 		"helm" : "",
	 		"tors" : "",
	 		"legs" : "",
	 		"weapon" : "",

	 		"helm_id" : 0,
	 		"tors_id" : 0,
	 		"legs_id" : 0,
	 		"weapon_id" : 0
	 	}
	 	sd.sdWrite(_pl_data)



def text(t):
	for i in t:
		print(i, end='', flush=True)
		sleep(0.01)
	sleep(0.1)


def palakion():
	while:
		text("1.Castle\n2.Trader\n3.Kazarms\n4.Menu\n")
		x = int(input("x: "))


init()