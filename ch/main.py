import items as I

inv = {}
pl = {
	'hp' : 100,
	'def' : 10,
	'shields' : 0,
	'dam' : 10,
	'crit' : 5
}

def addItem(key):
	global inv
	for k in inv:
		if k == key:
			inv[key] += 1
			return
	inv[key] =  1

def calculateParams():
	global inv
	for k in inv:
		if I.items[k]['type'] == 'augment':
			pl[I.items[k]['value'][0]] += I.items[k]['value'][1] * inv[k]

addItem("ep") #1
addItem("ep") #2
addItem("ep") #3
addItem("ep") #4
addItem("ep") #5
addItem("ep") #6
calculateParams()
print(inv['ep'])
print(pl)