#include "Cellnature_table.hpp"
#include "tinyxml.h"
#include "EeFileMemory.h"
#include "EeFilePackage.h"

CellnatureTableMgr* CellnatureTableMgr::m_pkCellnatureTableMgr = NULL;
CellnatureTableMgr* CellnatureTableMgr::Get()
{
    if(m_pkCellnatureTableMgr == NULL)
    {
        m_pkCellnatureTableMgr = new CellnatureTableMgr();
    }
    return m_pkCellnatureTableMgr;
}


const std::map<unsigned int, CellnatureTable*>& CellnatureTableMgr::GetCellnatureTableMap()
{
    return m_kCellnatureTableMap;
}

TableResArray CellnatureTableMgr::GetCellnatureTableVec()
{
    TableResArray kRecVec;
    for (std::map<unsigned int, CellnatureTable*>::iterator iMapItr = m_kCellnatureTableMap.begin(); iMapItr != m_kCellnatureTableMap.end(); ++iMapItr)
    {
        kRecVec.pushBack(iMapItr->second);
    }

    return kRecVec;
}

const CellnatureTable* CellnatureTableMgr::GetCellnatureTable(unsigned int iTypeID)
{
    std::map<unsigned int, CellnatureTable*>::iterator iter = m_kCellnatureTableMap.find(iTypeID);
    if(iter != m_kCellnatureTableMap.end())
    {
        return iter->second;
    }
    return NULL;
}

CellnatureTableMgr::CellnatureTableMgr()
{
    Load();
}

CellnatureTableMgr::~CellnatureTableMgr()
{
    m_kCellnatureTableMap.clear();
}

bool CellnatureTableMgr::Load()
{
    std::string path = "Data/Table/Cellnature.xml";
    FileMemory kMemory;
    if(!FileLoader::LoadTableFile(path.c_str(),kMemory))
    {
        return false;
    }

    TiXmlDocument doc;
    doc.Parse(kMemory.GetData());
    if (doc.Error())
    {
        std::string err = path + "   " + std::string(doc.ErrorDesc());
        // throw std::exception(err.c_str());
        return false;
    }

    TiXmlElement* root = doc.FirstChildElement("root");
    if (root == 0)
    {
        // throw std::exception("root is null!");
        return false;
    }

    TiXmlElement* element = root->FirstChildElement("content");
    while (element != 0)
    {
        CellnatureTable * row = new CellnatureTable();
        FillData(row, element);
        element = element->NextSiblingElement();
    }

    return true;
}

void CellnatureTableMgr::FillData(CellnatureTable* row, TiXmlElement* element)
{
    int int_value = 0;
    std::string str_value = "";
    double float_value = 0.0f;

    element->Attribute("CellID", &int_value);
    row->uiCellID = (unsigned int)int_value;
    str_value = element->Attribute("CellName");
    row->kCellName = str_value;
    str_value = element->Attribute("CellSize");
    row->kCellSize = str_value;
    element->Attribute("PassEfficiency", &int_value);
    row->uiPassEfficiency = (unsigned int)int_value;
    element->Attribute("AtkAdd", &int_value);
    row->uiAtkAdd = (unsigned int)int_value;
    element->Attribute("DefAdd", &int_value);
    row->uiDefAdd = (unsigned int)int_value;
    element->Attribute("HitAdd", &int_value);
    row->uiHitAdd = (unsigned int)int_value;
    element->Attribute("EvAdd", &int_value);
    row->uiEvAdd = (unsigned int)int_value;
    element->Attribute("HPRecovery", &int_value);
    row->uiHPRecovery = (unsigned int)int_value;
    element->Attribute("AtkTime", &int_value);
    row->uiAtkTime = (unsigned int)int_value;
    element->Attribute("MotherCell", &int_value);
    row->uiMotherCell = (unsigned int)int_value;
    element->Attribute("MinCent", &float_value);
    row->fMinCent = (float)float_value;
    element->Attribute("MaxCent", &float_value);
    row->fMaxCent = (float)float_value;
    element->Attribute("MinDistance", &int_value);
    row->uiMinDistance = (unsigned int)int_value;
    element->Attribute("SameDistance", &int_value);
    row->uiSameDistance = (unsigned int)int_value;

    m_kCellnatureTableMap[row->uiCellID] = row;
}
