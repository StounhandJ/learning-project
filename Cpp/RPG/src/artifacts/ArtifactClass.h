#include <iostream>
#include <string>
#ifndef RPG_ARTIFACTCLASS_H
#define RPG_ARTIFACTCLASS_H

int HELMET = 0;
int ARMOR = 1;
int HANDS = 2;
int LEGS = 3;

class ArtifactClass {
public:
    std::string getArtifactName() const{return ArtifactName;}
    int getGold() {return gold;}
    int getDamage() {return optionally_damage;}
    int getHP() {return optionally_HP;}
    int getDefense() {return optionally_defense;}
    int getType() {return type;}

    explicit ArtifactClass(int type=ARMOR,int gold=100, int optionally_damage=0, int optionally_HP=0, int optionally_defense=0):
    type(type), gold(gold), optionally_damage(optionally_damage), optionally_HP(optionally_HP),optionally_defense(optionally_defense)
    {

    }


private:
    std::string ArtifactName;
    int type,
        gold,
        optionally_damage,
        optionally_HP,
        optionally_defense;
};
#endif //RPG_ARTIFACTCLASS_H
