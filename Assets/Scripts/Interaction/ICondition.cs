using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICondition
{
    bool IsConditionMet();
}

public interface IResult
{
    void Execute();
}