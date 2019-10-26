using System;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Threading;

namespace GameOfLife
{
    public class Emulator
    {
        public GameStep GameStep { get; private set; }
        
        public int CurrentStep { get; private set; }

        private bool IsWorking;

        private const int MaxSteps = 1000;

        public Field Field { get; private set; }

        public Emulator(Field field)
        {
            Field = field;
            CurrentStep = 0;
            IsWorking = true;
        }

        public bool Execute()
        {
            if (CurrentStep < MaxSteps && Field.Pixels.Count != 0)
            {
                if (CurrentStep == 9)
                {
                    int r = 0;
                }
                CurrentStep++;
                GameStep = new GameStep(Field);
                GameStep.ExecuteStep();
                Field = GameStep.GetNewField();
            }
            else
            {
                IsWorking = false;
            }

            return IsWorking;
        }
    }
}