var edge = require('edge'),
	path = require('path'),
	dllPath = path.join(__dirname, '../src/bin/Release/slimdx_gamepad.dll'),
	
	newFunc = edge.func({
		assemblyFile: dllPath,
		methodName: 'New'
	}),
	destroyFunc = edge.func({
		assemblyFile: dllPath,
		methodName: 'Destroy'
	}),
	loadStateFunc = edge.func({
		assemblyFile: dllPath,
		methodName: 'LoadState'
	});
	
/**
 * Tracks the current state of a gamepad
 * @param {number} playerID		Which controller to connect to. If 0, will select any controller
 */
var Gamepad = function(playerID) {
	playerID = playerID || 0;
	if (!(this instanceof Gamepad)) {
		throw new Error('Must call Gamepad as a constructor ( new Gamepad( playerID ) )');
	} else if (playerID < 0 || playerID > 4) {
		throw new Error('playerID must be between 0 and 4');
	}
	
	this._playerID = playerID;
	var initialState = newFunc(playerID, true);
	for (var key in initialState) {
		this[key] = initialState[key];
	}
};

/**
 * Destroys the SlimDX reference in memory
 */
Gamepad.prototype.destroy = function() {
	destroyFunc(this._playerID, true);
	for (var key in this) {
		delete this[key];
	}
};

/**
 * Loads the current state of the gamepad
 */
Gamepad.prototype.loadState = function() {
	// Don't try to load after the object has been destroyed
	if (!this.hasOwnProperty('_playerID')) {
		return;
	}

	var state = loadStateFunc(this._playerID, true);
	for (var key in state) {
		this[key] = state[key];
	}
};

module.exports = Gamepad;