#include <iostream>
#include <string>
#include <utility>
#ifndef RPG_ARTIFACTCLASS_H
#define RPG_ARTIFACTCLASS_H

int const HELMET = 0;
int const ARMOR = 1;
int const HANDS = 2;
int const LEGS = 3;

class ArtifactClass {
public:
    std::string getArtifactName() const{return ArtifactName;}
    int getType() const{return type;}
    int getGold() const{return gold;}
    int getDamage() const{return optionally_damage;}
    int getHP() const{return optionally_HP;}
    int getDefense() const{return optionally_defense;}
    int getKnowledge() const{return optionally_knowledge;}
    int getMagicPower() const{return optionally_magic_power;}
    int getMana() const{return optionally_mana;}

    explicit ArtifactClass(std::string name, int type=ARMOR,int gold=10, int optionally_damage=0, int optionally_HP=0,
                           int optionally_defense=0, int optionally_knowledge=0, int optionally_magic_power=0, int optionally_mana = 0):
    ArtifactName(std::move(name)), type(type), gold(gold), optionally_damage(optionally_damage), optionally_HP(optionally_HP),
    optionally_defense(optionally_defense), optionally_knowledge(optionally_knowledge), optionally_magic_power(optionally_magic_power), optionally_mana(optionally_mana)
    {

    }


private:
    std::string ArtifactName;
    int type,
        gold,
        optionally_damage,
        optionally_HP,
        optionally_defense,
        optionally_knowledge,
        optionally_magic_power,
        optionally_mana;
};
#endif //RPG_ARTIFACTCLASS_H
