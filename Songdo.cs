﻿using System;
using static Class1;

public class Class1
{
    public class Player()
    {
        public string Name;
        public JobType Job = JobType.Warrior;
        public int Level = 1;

        // 기본 능력치
        public int BaseAttack = 10;
        public int BaseDefense = 5;
        public int MaxHP = 100;
        public int CurrentHP = 100;
        public int Gold = 1500;

        //아이템 장착으로 변한 능력치
        public int BonusAttack => EquippedItems.Sum(item => item.AttackBonus);
        public int BonusDefense => EquippedItems.Sum(item => item.DefenseBonus);
        public int BonusMaxHP => EquippedItems.Sum(item => item.MaxHP);

        //최종 능력치
        public int TotalAttack => BaseAttack + BonusAttack;
        public int TotalDefense => BaseDefense + BonusDefense;
        public int TotalMaxHP => MaxHP + BonusMaxHP;

        public List<Item> Inventory = new List<Item>();
        public List<Item> EquippedItems = new List<Item>();

        //직업에 따라 능력치 조절해주기 전사가 기본 스텟이니까 도적과 마법사만 조절
        //밸런스 공격력 1당 최대체력 -5, 방어력 -0.5(내림)
        public void ApplyJobStats()
        {
            switch (Job)
            {
                case JobType.Thief:
                    BaseAttack += 2;
                    BaseDefense -= 1;
                    MaxHP -= 10;
                    break;
                case JobType.Mage:
                    BaseAttack += 5;
                    BaseDefense -= 2;
                    MaxHP -= 25;
                    break;
            }

            CurrentHP = MaxHP;
        }
    }

    enum JobType
    {
        Warrior,    // 전사
        Thief,      // 도적
        Mage        // 마법사
    }

    public static void PlayerStat()
    {
        Console.WriteLine("\n===== 캐릭터 정보 =====");
        Console.WriteLine($"이름: {player.Name}");
        Console.WriteLine($"직업: {player.Job}");
        Console.WriteLine($"레벨: {player.Level}");
        Console.WriteLine($"공격력: {player.BaseAttack} (+{player.BonusAttack}) => {player.TotalAttack}");
        Console.WriteLine($"방어력: {player.BaseDefense} (+{player.BonusDefense}) => {player.TotalDefense}");
        Console.WriteLine($"체력: {player.CurrentHP} / {player.TotalMaxHP}");
        Console.WriteLine($"Gold: {player.Gold}");

        Console.WriteLine("\n[장착 중인 아이템]");
        if (player.EquippedItems.Count == 0)
        {
            Console.WriteLine("없음");
        }
        else
        {
            foreach (var item in player.EquippedItems)
            {
                Console.WriteLine($"- {item}");
            }
        }

        Console.WriteLine("========================\n");
    }


}
