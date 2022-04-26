using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Nethereum.JsonRpc.UnityClient;
using PortfolioDapp.Contracts.MyToken.ContractDefinition;
using PortfolioDapp.Contracts.ShipGame.ContractDefinition;

public class BlockNumber : MonoBehaviour
{
    public List<ShipData> ShipsDatas = new List<ShipData>();

    [SerializeField]
    List<UpdateShipsDataGUI> ShipsUI;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetBlockNumber());

    }

    private IEnumerator GetBlockNumber()
    {
        string url = "https://rinkeby.infura.io/v3/67281ea70f3e4e6b8640981141c99d97";
        string tokenContractAddress = "0xc90f243D9dF04ae54a5B5DFEeb77789Af2e69438";
        string shipContractAddress = "0x1C83A32ebb2c3983F1AE0B92a4645d2A47e038db";
        var blockNumberRequest = new EthBlockNumberUnityRequest(url);
        yield return blockNumberRequest.SendRequest();


        var queryRequest = new QueryUnityRequest<NameFunction, NameOutputDTO>(url, tokenContractAddress);
        // call LeaderboardFunctionBase with 1 param (leaderboardIndex) to get the user name score
        yield return queryRequest.Query(new NameFunction() {}, tokenContractAddress);
        // print in console

        var queryRequest2 = new QueryUnityRequest<BalanceOfFunction, BalanceOfOutputDTO>(url, tokenContractAddress);
        // call LeaderboardFunctionBase with 1 param (leaderboardIndex) to get the user name score
        yield return queryRequest2.Query(new BalanceOfFunction() { Account = "0x88083AEf2a08b4507F7fD69A289b3FCE0f2bfAcc" }, tokenContractAddress);
        // print in console

        var queryRequest3 = new QueryUnityRequest<GetOwnedShipsFunction, GetOwnedShipsOutputDTO>(url, shipContractAddress);
        // call LeaderboardFunctionBase with 1 param (leaderboardIndex) to get the user name score
        yield return queryRequest3.Query(new GetOwnedShipsFunction() { FromAddress = "0x88083AEf2a08b4507F7fD69A289b3FCE0f2bfAcc" }, shipContractAddress);
        // print in console

        for (int i = 0; i < queryRequest3.Result.ReturnValue1.Count; i++)
        {
            ShipData ship = new ShipData();
            ship.Name = queryRequest3.Result.ReturnValue1[i];
            ship.Life = queryRequest3.Result.ReturnValue2[i];
            ship.Attack = queryRequest3.Result.ReturnValue3[i];
            ship.EXP = queryRequest3.Result.ReturnValue4[i];
            ship.Level = queryRequest3.Result.ReturnValue5[i];
            ship.PendingRewards = queryRequest3.Result.ReturnValue6[i];
            ship.Owner = queryRequest3.Result.ReturnValue7[i];
            ship.Id = queryRequest3.Result.ReturnValue8[i];

            ShipsUI[i].SetShipDatas(ship);
        }

        foreach (var item in ShipsUI)
        {
            print(item.data.Name);
        }

    }
}