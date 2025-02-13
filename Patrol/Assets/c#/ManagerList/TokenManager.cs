using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TokenManager 
{
    public void RefreshToken(ref CancellationTokenSource cts)
    {

        if (cts != null)
        {

            if (!cts.IsCancellationRequested)
            { //��� ��û�� ������ 
                cts.Cancel();
            }
            cts.Dispose();
        }

        cts = new CancellationTokenSource();//���ο� ��ū ����
    }
}
