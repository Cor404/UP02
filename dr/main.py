from time import sleep
from random import randint
import mons as mons
import sd

trader_items = {
	"life_water" : {
		"price" : 100
	},
	"life_tear" : {
		"price" : 450
	}
}

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
	while(True):
		text("1.Castle\n2.Trader\n3.Kazarms\n4.Menu\n")
		x = int(input("x: "))

		if(x == 1):
			pass
		if(x == 2):
			while(True):
				text("1.Buy items\n2.Buy equipment\n3.Sell items & equipment\n")
				x = int(input("x: "))
				if(x == 1):
					ii = 1
					for i in trader_items:
						print(str(ii)+"."+str(i), trader_items[i]["price"], "rubies")
						ii += 1
palakion()