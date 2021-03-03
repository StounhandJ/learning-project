cmake_minimum_required(VERSION 3.17)
project(RPG)

set(CMAKE_CXX_STANDARD 20)

add_executable(RPG main.cpp src/hero/HeroClass.h src/hero/grade/WarriorClass.h src/skills/SkillClass.h src/artifacts/ArtifactClass.h)