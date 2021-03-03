#include <iostream>
#include <string>
#include "src/hero/HeroClass.h"
#ifndef RPG_HEROGRADE_H
#define RPG_HEROGRADE_H

class WarriorClass : public HeroClass {
public:

    explicit WarriorClass(std::string input_name)
    {
        GradeName = "Воин";
        HeroName = input_name;
        HP = 200;
        damage = 10;
        defense = 25;
    }

protected:
    virtual void up_level()
    {
        level+=1;
        damage+=5;
        maxHP+=20;
        defense+=5;
        HP = HP<maxHP/100*70?maxHP/100*70:maxHP;
    }

};
#endif //RPG_HEROGRADE_H