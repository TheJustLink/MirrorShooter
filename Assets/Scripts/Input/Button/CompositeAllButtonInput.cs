using System.Collections.Generic;
using System.Linq;

namespace MirrorShooter.Input.Button
{
    class CompositeAllButtonInput : IButtonInput
    {
        private readonly IReadOnlyCollection<IButtonInput> _buttonInputs;
        
        public CompositeAllButtonInput(IReadOnlyCollection<IButtonInput> buttonInputs) => _buttonInputs = buttonInputs;

        public bool GetButton() => _buttonInputs.All(buttonInput => buttonInput.GetButton());
        public bool GetButtonDown() => _buttonInputs.All(buttonInput => buttonInput.GetButtonDown());
        public bool GetButtonUp() => _buttonInputs.All(buttonInput => buttonInput.GetButtonUp());
    }
}