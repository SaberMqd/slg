#pragma once
#pragma execution_character_set("utf-8")

#include <string>
#include <map>
#include "SeTableResBase.h"



//  自动生成表结构
struct CellnatureTable : SeTableResBase
{
    unsigned int               uiCellID                            ;   //  编号   
    std::string                kCellName                           ;   //  地块名称   
    std::string                kCellSize                           ;   //  地块尺寸   
    unsigned int               uiPassEfficiency                    ;   //  通行效率   
    unsigned int               uiAtkAdd                            ;   //  攻击加成   
    unsigned int               uiDefAdd                            ;   //  防御加成   
    unsigned int               uiHitAdd                            ;   //  命中加成   
    unsigned int               uiEvAdd                             ;   //  闪避加成   
    unsigned int               uiHPRecovery                        ;   //  生命回复   
    unsigned int               uiAtkTime                           ;   //  破坏次数   
    unsigned int               uiMotherCell                        ;   //  母地块   
    float                      fMinCent                            ;   //  地块最小占比   
    float                      fMaxCent                            ;   //  地块最大占比   
    unsigned int               uiMinDistance                       ;   //  边界最小距离   
    unsigned int               uiSameDistance                      ;   //  相同地块最小距离   
};

class TiXmlElement;
class CellnatureTableMgr
{
public:
    static CellnatureTableMgr* Get();
    CellnatureTableMgr();
    ~CellnatureTableMgr();

    const CellnatureTable* GetCellnatureTable(unsigned int iTypeID);
    const std::map<unsigned int, CellnatureTable*>& GetCellnatureTableMap();
    TableResArray GetCellnatureTableVec();

private:
    bool    Load();
    void    FillData(CellnatureTable* row, TiXmlElement* element);

    std::map<unsigned int,CellnatureTable*>      m_kCellnatureTableMap;
    static CellnatureTableMgr* m_pkCellnatureTableMgr;
};
