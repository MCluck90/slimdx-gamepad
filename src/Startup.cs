// Disable 'await' warnings
#pragma warning disable 1998

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace slimdx_gamepad {
    public class Startup {
        private static Dictionary<int, Gamepad> _controllerInstances = new Dictionary<int, Gamepad>();

        /// <summary>
        /// Create a new Gamepad instance
        /// </summary>
        /// <param name="input">int playerID: Which controller to connect to</param>
        /// <returns>new Gamepad</returns>
        public async Task<object> New(dynamic input) {
            int playerID = (int)input;
            if (playerID < 0 || playerID > 4) {
                return null;
            }
            SlimDX.XInput.UserIndex userIndex = SlimDX.XInput.UserIndex.Any;
            switch (playerID) {
                case 1:
                    userIndex = SlimDX.XInput.UserIndex.One;
                    break;
                case 2:
                    userIndex = SlimDX.XInput.UserIndex.Two;
                    break;
                case 3:
                    userIndex = SlimDX.XInput.UserIndex.Three;
                    break;
                case 4:
                    userIndex = SlimDX.XInput.UserIndex.Four;
                    break;
            }
            if (_controllerInstances.ContainsKey(playerID)) {
                _controllerInstances[playerID] = new Gamepad(new SlimDX.XInput.Controller(userIndex));
            } else {
                _controllerInstances.Add(playerID, new Gamepad(new SlimDX.XInput.Controller(userIndex)));
            }
            return _controllerInstances[playerID];
        }

        /// <summary>
        /// Destroys an instance of Gamepad
        /// </summary>
        /// <param name="input">int playerID: Which controller instance to destroy</param>
        /// <returns></returns>
        public async Task<object> Destroy(dynamic input) {
            int playerID = (int)input;
            if (_controllerInstances.ContainsKey(playerID)) {
                _controllerInstances.Remove(playerID);
            }
            return null;
        }

        /// <summary>
        /// Loads the current gamepad state
        /// </summary>
        /// <param name="input">int playerID: Which controller to check</param>
        /// <returns>Gamepad</returns>
        public async Task<object> LoadState(dynamic input) {
            int playerID = (int)input;
            if (_controllerInstances.ContainsKey(playerID)) {
                _controllerInstances[playerID].LoadState();
                return _controllerInstances[playerID];
            }
            return null;
        }
    }
}
