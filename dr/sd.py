import os
import json

path = "savedata.json"

def sdCheck():
	if os.path.exists(path) and os.path.isfile(path):
		return True
	else:
		return False

def sdCreate():
	with open(path, "w") as f:
		pass

def sdRead():
	with open(path, "r") as f:
		return json.load(f)

def sdWrite(data):
	with open(path, "w") as f:
		json.dump(data, f, indent=4, ensure_ascii=False)