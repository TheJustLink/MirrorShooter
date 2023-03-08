using System.Collections.Generic;
using System.Linq;

namespace MirrorShooter.Input.Button
{
    class CompositeAnyButtonInput : IButtonInput
    {
        private readonly IReadOnlyCollection<IButtonInput> _buttonInputs;
        
        public CompositeAnyButtonInput(IReadOnlyCollection<IButtonInput> buttonInputs) => _buttonInputs = buttonInputs;

        public bool GetButton() => _buttonInputs.Any(buttonInput => buttonInput.GetButton());
        public bool GetButtonDown() => _buttonInputs.Any(buttonInput => buttonInput.GetButtonDown());
        public bool GetButtonUp() => _buttonInputs.Any(buttonInput => buttonInput.GetButtonUp());
    }
}