# SlimDX Gamepad

*Provides a simple interface for accessing the Xbox controller through SlimDX*

### Usage

```javascript
var Gamepad = require('slimdx-gamepad');
var gamepad1 = new Gamepad(1);
```

### Constructor
* new **Gamepad(** *playerID* **)**
	* *int* **playerID**: Which controller to listen to. 0 will use any controller available.

### Properties

```javascript
{
	A: bool,
	B: bool,
	X: bool,
	Y: bool,
	Start: bool,
	Back: bool,
	DPad: {
	    Up: bool,
	    Down: bool,
	    Left: bool,
	    Right: bool
	},
	LeftBumper: bool,
	RightBumper: bool,
	LeftTrigger: float,
	RightTrigger: float,
	Thumbsticks: {
	    Left: {
	        Click: bool,
	        X: float,
	        Y: float
	    },
	    Right: {
	        Click: bool,
	        X: float,
	        Y: float
	    }
	}
}
```

### Methods

* **loadState()**
	* Loads the current state of the gamepad
* **destroy()**
	* Destroys gamepad reference