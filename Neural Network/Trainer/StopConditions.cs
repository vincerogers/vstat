using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VStats.Trainer
{
    public enum StopConditions
    {
        maxEpochs,
        maxTimeMinutes,
        minValidationAccuarcy
    }
}
