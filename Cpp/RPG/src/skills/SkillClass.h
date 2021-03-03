#include <iostream>
#include <string>
#include <utility>
#ifndef RPG_SKILLCLASS_H
#define RPG_SKILLCLASS_H

class SkillClass {
public:
    std::string name;
    explicit SkillClass(std::string input_name)
    {
        name = std::move(input_name);
    }
};
#endif //RPG_SKILLCLASS_H
