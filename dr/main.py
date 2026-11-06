from time import sleep

items = {'lezv' : {'dam' : 0.2}}

enem = {
'test01' : {'hp' : 10,
		  'dam' : 1,
		  'def' : 1}
}

zones = {'forest' : {'mons' : ['test01']}}

_hp_max = 10
_hp = _hp_max
_xp_max = 10
_xp = _xp_max
_dam = 3
_crit = 0
_inv = {}
_def = 3
_lvl = 1

e_hp_max = 0
e_hp = 0
e_dam = 0
e_def = 0

def text(t):
	for i in t:
		print(i, end='', flush=True)
		sleep(0.01)
	sleep(0.1)

def _isAlive():
	if _hp <= 0:
		return False
	return True

def lvlUP():
	_lvl += 1
	_xp_max *= 1.2
	_hp_max *= 1.2
	_def += 2
	_dam *= 1.4
	_xp -= _xp_max

	_hp = _hp_max

def _hit():
	global e_def, e_hp, _dam
	dam = _dam - e_def
	if _dam - e_def <= 0:
		dam = 1
	e_hp -= dam

def e_init(name):
	global e_hp_max, e_hp, e_dam, e_def
	e_hp_max = enem[name]['hp']
	e_hp = e_hp_max
	e_dam = enem[name]['dam']
	e_def = enem[name]['def']

def e_hit():
	global e_dam, _def, _hp
	dam = e_dam - _def
	if e_dam - _def <= 0:
		dam = 1
	_hp -= dam

def e_isAlive():
	if e_hp <= 0:
		text('Enemy is down...')
		return False
	return True

def fight():
	while _isAlive() and e_isAlive():
		print('Enemy : \nHP: ' + str(e_hp) + '/' + str(e_hp_max) + '\nDefense: ' + str(e_def) + '\nDamage: ' + str(e_dam) + '\n\n')
		print('Player : \nHP: ' + str(_hp) + '/' + str(_hp_max) + '\nDefense: ' + str(_def) + '\nDamage: ' + str(_dam) + '\n\n')
		print("1.Hit\n2.Defend\n3.Run\n")
		x = input('x : ')
		if x == '1':
			_hit()
			e_hit()

e_init('test01')
fight()