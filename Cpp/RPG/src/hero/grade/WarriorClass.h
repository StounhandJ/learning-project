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

    }


};
#endif //RPG_HEROGRADE_H