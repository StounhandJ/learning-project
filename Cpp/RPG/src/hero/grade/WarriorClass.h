#include <iostream>
#include <string>
#include <utility>
#include <map>
#include "src/skills/SkillClass.h"
#include "src/hero/HeroClass.h"
#ifndef RPG_HEROGRADE_H
#define RPG_HEROGRADE_H

std::map <std::string,SkillClass> WarriorListSkill = {
        {"StrongBlow", SkillClass("Сильный удар", 1, 100, 10, NON_ELEMENT)},
        {"TorsionalImpact", SkillClass("Крутящий удар", 1, 100, 10, NON_ELEMENT)},
        {"HeavenStrike", SkillClass("Удар небес", 1, 300, 50, NON_ELEMENT)},
};

class WarriorClass : public HeroClass {
public:

    explicit WarriorClass(std::string name)
    {
        this->GradeName = "Воин";
        this->HeroName = std::move(name);
        this->HP = 200;
        this->damage = 10;
        this->defense = 25;
    }

protected:
    virtual void up_level()
    {
        this->level+=1;
        this->damage+=5;
        this->maxHP+=20;
        this->defense+=5;
        this->HP = HP<maxHP/100*70?maxHP/100*70:maxHP;
    }

};
#endif //RPG_HEROGRADE_H