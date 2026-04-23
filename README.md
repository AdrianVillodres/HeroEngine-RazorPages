**UML diagram:** [Diagram](https://drive.google.com/file/d/1nX7f7bF2IlZ7h34crU18ZdwcBDO_DRba/view?usp=sharing)

## Chapter 1

This first chapter is about doing the main structure of the hero classes, the project has a hero abstract class and then the children classes warrior, mage and rogue, with their own elements.

### Test case 1

**Character1:** Dalia (Level 3, MaxHP 150, CurrentHealth 150)  
**Character2:** Abalon (Level 3, MaxHP 150, CurrentHealth 150)  
**Damage:** 13  

| #Instruction | #Iteration | Name   | Level | MaxHP | CurrentHealth | Damage | RealDamage | Condition / Output |
|--------------|------------|--------|-------|-------|---------------|--------|------------|--------------------|
| 1            | -          | Abalon | 3     | 150   | 150           | -      | -          | -                  |
| 2            | -          | Dalia  | 3     | 150   | 150           | -      | -          | -                  |
| 3            | -          | Dalia  | 3     | 150   | 150           | 13     | 13         | -                  |
| 4            | -          | Dalia  | 3     | 150   | 150           | 13     | 13         | -                  |
| 5            | -          | Abalon | 3     | 150   | 137           | 13     | 13         | -                  |
| 6            | -          | Abalon | 3     | 150   | 137           | -      | -          | Output: "Abalon receives 13 HP: 137/150" |

---

### Test case 2

**Character1:** Dalia (Level 1, MaxHP 50, CurrentHealth 50)  
**Character2:** Abalon (Level 1, MaxHP 50, CurrentHealth 50)  
**Damage:** 0  

| #Instruction | #Iteration | Name   | Level | MaxHP | CurrentHealth | Damage | RealDamage | Condition / Output |
|--------------|------------|--------|-------|-------|---------------|--------|------------|--------------------|
| 1            | -          | Dalia  | 1     | 50    | 50            | -      | -          | -                  |
| 2            | -          | Dalia  | 1     | 50    | 50            | 0      | 0          | -                  |
| 3            | -          | Dalia  | 1     | 50    | 50            | -      | 20         | -                  |
| 4            | -          | Abalon | 1     | 50    | 50            | 0      | 0          | -                  |
| 5            | -          | Abalon | 1     | 50    | 50            | -      | -          | Output: "Abalon receives 0 HP: 50/50" |

---

### Test case 3

**Character1:** Dalia (Level 3, MaxHP 150, CurrentHealth 150)  
**Character2:** Abalon (Level 3, MaxHP 150, CurrentHealth 150)  
**Damage:** 13  

| #Instruction | #Iteration | Name   | Level | MaxHP | DefenseBuffCount | Damage | RealDamage | Condition        |
|--------------|------------|--------|-------|-------|------------------|--------|------------|------------------|
| 1            | -          | Dalia  | 3     | 150   | 0                | -      | -          | -                |
| 2            | -          | Dalia  | 3     | 150   | 0                | 13     | 0          | -                |
| 3            | -          | Dalia  | 3     | 150   | 0                | -      | 0          | -                |
| 4            | -          | Abalon | 3     | 150   | 150              | 0      | 0          | No damage applied |

---
## Chapter 2

This chapter is about doing an ability system to make the characters interact in different ways. The abilities are clasified by rarity and type, and the cost and power are calculated by the rarity, then, you can add any ability to any character, list them by character and cast the abilities.

## Test case 1: name = Swartz of the Ice Queen, rarity = Legendary, Type = Attack

| #Instruction | #Iteration | Name                    | Rarity     | Type   | Cost           | Power          | Condition |
|--------------|------------|-------------------------|------------|--------|----------------|----------------|-----------|
| -            |            |                         |            |        |                |                |           |
|              |            | Name                    | Rarity     | Type   | Cost           | Power          | Condition |
| 1            | -          | Swartz of the Ice Queen | Legendary  | Attack | (int)Rarity    | (int)Rarity    |           |
| 2            | -          | Swartz of the Ice Queen | Legendary  | Attack | (int)Rarity    | (int)Rarity    | dalia.Add(swartz) |
| 3            | -          | Swartz of the Ice Queen | Legendary  | Attack | (int)Rarity    | (int)Rarity    | dalia.listAllAbilities() |
| 4           |            | Swartz of the Ice Queen | Legendary  | Attack | (int)Rarity    | (int)Rarity    | Output: [Legendary]   Swartz of the Ice Queen     Type: Attack       Cost: 40 mana |

---

## Test case 2: name = Rock throw, rarity = Common, Type = Attack

| #Instruction | #Iteration | Name       | Rarity | Type   | Cost        | Power       | Condition |
|--------------|------------|------------|--------|--------|-------------|-------------|-----------|
| -            |            |            |        |        |             |             |           |
|              |            | Name       | Rarity | Type   | Cost        | Power       | Condition |
| 1            | -          | Rock throw | Common | Attack | (int)Rarity | (int)Rarity |           |
| 2            | -          | Rock throw | Common | Attack | (int)Rarity | (int)Rarity | dalia.Add(throw) |
| 3            | -          | Rock throw | Common | Attack | (int)Rarity | (int)Rarity | dalia.listAllAbilities() |
| 4            |            | Rock throw | Common | Attack | (int)Rarity | (int)Rarity | Output: [Common]   Rock throw    Type: Attack       Cost: 5 mana |

---

## Test case 3: name = Rock throw, rarity = Common, Type = Attack (We are assuming that we already have this ability in the list)

| #Instruction | #Iteration | Name       | Rarity | Type   | Cost        | Power       | Condition |
|--------------|------------|------------|--------|--------|-------------|-------------|-----------|
| -            |            |            |        |        |             |             |           |
|              |            | Name       | Rarity | Type   | Cost        | Power       | Condition |
| 1            | -          | Rock throw | Common | -      | -           | -           |           |
| 2            | -          | Rock throw | Common | Attack | (int)Rarity | (int)Rarity | dalia.Add(throw) |
| 3            | -          | Rock throw | Common | Attack | (int)Rarity | (int)Rarity | Output = “This hero already has the ability” |

---

## Chapter 3

This chapter is about making the combat engine of the project, the way it works is by first, adding your characters to a list, then the method will check if there are fighters to use, if its true, will check if at least one character of each side is alive, if so, the battle will begin, the system will pick a random number to select the oponent and the ability and the will print the log of the combat and save it into a file. When the cobat is done, the screen will show you the total damage dealed, the most profitable hero and the enemy that died in less rounds.

## Test case 1: List<ACharacter>: abalon, dalia, mercer, loki, shadow, altair (the case will be so long if I put all iterations, so I will put 2 only, but the rest of the iterations are the same)

| #Instruction | #Iteration | List<ACharacter>                          | Attack         | Target               | Condition |
|--------------|------------|-------------------------------------------|----------------|----------------------|-----------|
| 1            | -          | abalon, dalia, mercer, loki, shadow, altair | -              | -                    | fighters.Add(abalon); fighters.Add(dalia); fighters.Add(mercer); fighters.Add(loki); fighters.Add(shadow); fighters.Add(altair); |
| 2            | -          | abalon, dalia, mercer, loki, shadow, altair | -              | -                    | fighters.Count > 0 = true |
| 3            | 1-1        | abalon, dalia, mercer, loki, shadow, altair | -              | -                    | fighters.Any(f => f.IsAlive && f.CharType == "HERO") && fighters.Any(f => f.IsAlive && f.CharType == "ENEMY") = true |
| 3            | 1-1        | abalon, dalia, mercer, loki, shadow, altair | ability(random) | target = enemy(random) | Output: HERO Abalon > Hellfire of demise > Boss Altair -> 50 dmg |
| 3            | 1-2        | abalon, dalia, mercer, loki, shadow, altair | ability(random) | target = enemy(random) | Output: HERO Dalia > Swartz of the Ice Queen > Minion Loki -> 80 dmg |
| 4            | 2-1        | abalon, dalia, mercer, loki, shadow, altair | ability(random) | target = enemy(random) | Output: HERO Abalon > Hellfire of demise > Boss Altair -> 40 dmg | DEFEATED! |
| 4            | 2-2        | abalon, dalia, mercer, loki, shadow, altair | ability(random) | target = enemy(random) | Output: ENEMY Minion Loki > Corrupt memory > Abalon -> 24 dmg |
| 5            | -          | abalon, dalia, mercer, loki, shadow, altair | -              | -                    | Output: The total damage that was dealed in all the combat is: 594<br>The most profitable hero is: Abalon<br>The enemy that survived least rounds is: Boss Altair |

---

## Test case 2: List<ACharacter>: abalon, altair

| #Instruction | #Iteration | List<ACharacter> | Attack         | Target               | Condition |
|--------------|------------|------------------|----------------|----------------------|-----------|
| 1            | -          | abalon, altair   | -              | -                    | fighters.Add(abalon); fighters.Add(altair); |
| 2            | -          | abalon, altair   | -              | -                    | fighters.Count > 0 = true |
| 3            | 1-1        | abalon, altair   | -              | -                    | fighters.Any(f => f.IsAlive && f.CharType == "HERO") && fighters.Any(f => f.IsAlive && f.CharType == "ENEMY") = true |
| 3            | 1-1        | abalon, altair   | ability(random) | target = enemy(random) | Output: HERO Abalon > Hellfire of demise > Boss Altair -> 50 dmg |
| 3            | 1-2        | abalon, altair   | ability(random) | target = enemy(random) | Output: ENEMY Boss Altair > Corrupt memory > Abalon -> 24 dmg |
| 4            | 2-1        | abalon, altair   | -              | -                    | fighters.Any(f => f.IsAlive && f.CharType == "HERO") && fighters.Any(f => f.IsAlive && f.CharType == "ENEMY") = true |
| 4            | 2-1        | abalon, altair   | ability(random) | target = enemy(random) | Output: HERO Abalon > Hellfire of demise > Boss Altair -> 50 dmg | DEFEATED! |
| 5            | -          | abalon, altair   | -              | -                    | Output: The total damage that was dealed in all the combat is: 142<br>The most profitable hero is: Abalon<br>The enemy that survived least rounds is: Boss Altair |

---

## Test case 3: List<ACharacter>: empty

| #Instruction | #Iteration | List<ACharacter> | Attack | Target | Condition |
|--------------|------------|------------------|--------|--------|-----------|
| 1            | -          | -                | -      | -      | fighters.Add(abalon); fighters.Add(altair); |
| 2            | -          | -                | -      | -      | fighters.Count > 0 = false |
| 3            | -          | -                | -      | -      | Output: There are no fighters |

---

To execute the program, just click play, the combat system is automatic.
