using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SLMPLauncher
{
    public static class FuncClear
    {
        static List<string> CustomIgnoreList = new List<string>();
        static List<string> IgnoreFilesList = new List<string> { @"tesv.exe", @"steam_rld.ini", @"steam_api.dll", @"skyrim\unrar.exe", @"skyrim\slmplauncher.ini", @"skyrim\slmplauncher.exe", @"skyrim\slmpignorefiles.ini", @"skyrim\skyrimprefs.ini", @"skyrim\skyrim.ini", @"skyrim.exe", @"skse_loader.dll", @"skse_1_9_32.dll", @"skse.exe", @"logs\.logs.txt", @"enbseries.ini", @"enblocal.ini", @"enbhost.exe", @"data\wyrmstooth.esp", @"data\wyrmstooth.bsa", @"data\wondersofweather.esp", @"data\wondersofweather.bsa", @"data\wearable lantern.esp", @"data\wearable lantern.bsa", @"data\update.esm", @"data\update.bsa", @"data\unofficial skyrim legendary edition patch.esp", @"data\unofficial skyrim legendary edition patch.bsa", @"data\uiextensions.esp", @"data\uiextensions.bsa", @"data\tradebarter.esp", @"data\tradebarter.bsa", @"data\tools\generatefnis_for_users\temporary_logs\.logs.txt", @"data\tools\generatefnis_for_users\patchlist.txt", @"data\tools\generatefnis_for_users\patchanimationfiles.txt", @"data\tools\generatefnis_for_users\mypatches.txt", @"data\tools\generatefnis_for_users\hkxcmd.exe", @"data\tools\generatefnis_for_users\generatefnisforusers.exe", @"data\tools\generatefnis_for_users\fnis_templates.txt", @"data\tools\generatefnis_for_users\dontaskagainforlink.txt", @"data\tools\generatefnis_for_users\debugdata.txt", @"data\tools\generatefnis_for_users\customprecachefiles.txt", @"data\tools\generatefnis_for_users\animvars.txt", @"data\tools\generatefnis_for_users\animevents.txt", @"data\tools\generatefnis_for_users\alternate_animationgroups.txt", @"data\staticloadingscreens.esp", @"data\staticloadingscreens.bsa", @"data\skyui.esp", @"data\skyui.bsa", @"data\skyrim.esm", @"data\skyproc patchers\dual sheath redux patch\dual sheath redux patch.jar", @"data\skse\skse.ini", @"data\skse\plugins\which_quests_item.ini", @"data\skse\plugins\which_quests_item.dll", @"data\skse\plugins\to_your_face.ini", @"data\skse\plugins\to_your_face.dll", @"data\skse\plugins\togglewalkrunfix.dll", @"data\skse\plugins\storageutil.dll", @"data\skse\plugins\skyrimsouls.ini", @"data\skse\plugins\skyrimsouls.dll", @"data\skse\plugins\skse_russian_helper.dll", @"data\skse\plugins\skse_enhancedcamera.ini", @"data\skse\plugins\skse_enhancedcamera.dll", @"data\skse\plugins\ru_fix.dll", @"data\skse\plugins\osa.dll", @"data\skse\plugins\nioverride.ini", @"data\skse\plugins\nioverride.dll", @"data\skse\plugins\mfgconsole.ini", @"data\skse\plugins\mfgconsole.dll", @"data\skse\plugins\memoryblockslog.ini", @"data\skse\plugins\memoryblockslog.dll", @"data\skse\plugins\loadgamefix.dll", @"data\skse\plugins\improvement_names.ini", @"data\skse\plugins\improvement_names.dll", @"data\skse\plugins\hdtphysicsextensionsdefaultbbp.xml", @"data\skse\plugins\hdtphysicsextensions.ini", @"data\skse\plugins\hdtphysicsextensions.dll", @"data\skse\plugins\encounter_zones_unlocked.ini", @"data\skse\plugins\encounter_zones_unlocked.dll", @"data\skse\plugins\enchantreloadfix.dll", @"data\skse\plugins\crashfixplugin.ini", @"data\skse\plugins\crashfixplugin.dll", @"data\skse\plugins\cpconvert.ini", @"data\skse\plugins\cpconvert.dll", @"data\skse\plugins\chargen.ini", @"data\skse\plugins\chargen.dll", @"data\skse\plugins\camerascripter.dll", @"data\skse\plugins\bugfixplugin.ini", @"data\skse\plugins\bugfixplugin.dll", @"data\skse\plugins\barterfix.dll", @"data\skse\plugins\armor_rating_rescaled.ini", @"data\skse\plugins\armor_rating_rescaled.dll", @"data\skse\plugins\ahzmorehudplugin.dll", @"data\skse\plugins\additemmenu2.ini", @"data\skse\plugins\additemmenu2.dll", @"data\scripts\fnis_aa2.pex", @"data\scripts\fnisversiongenerated.pex", @"data\racemenu.esp", @"data\racemenu.bsa", @"data\rmOverlays.esp", @"data\rmOverlays.bsa", @"data\quests markers.esp", @"data\quests markers.bsa", @"data\osa.esm", @"data\osa.bsa", @"data\ordinator.esp", @"data\ordinator.bsa", @"data\meshes\animationsetdatasinglefile.txt", @"data\meshes\animationdatasinglefile.txt", @"data\meshes\actors\character\characters\defaultmale.hkx", @"data\meshes\actors\character\characters female\defaultfemale.hkx", @"data\meshes\actors\character\character assets\skeleton.hkx", @"data\meshes\actors\character\character assets female\skeleton_female.hkx", @"data\leveled enemy.esp", @"data\leveled enemy.bsa", @"data\landscape improved.esp", @"data\landscape improved.bsa", @"data\jaxonzmapmarkers.esp", @"data\jaxonzmapmarkers.bsa", @"data\inviseyefixes.esp", @"data\inviseyefixes.bsa", @"data\interiors furniture fix.esp", @"data\interiors furniture fix.bsa", @"data\ineed.esp", @"data\ineed.bsa", @"data\ineed - dd.esp", @"data\immersive citizens.esp", @"data\immersive citizens.bsa", @"data\ihud.esp", @"data\ihud.bsa", @"data\horsearmor.esp", @"data\horsearmor.bsa", @"data\helmettoggle.esp", @"data\helmettoggle.bsa", @"data\hearthfires.esm", @"data\headtracking.esp", @"data\headtracking.bsa", @"data\getsnowy.esp", @"data\getsnowy.bsa", @"data\gamevoice2.bsa", @"data\gamevoice1.bsa", @"data\gametext9.bsa", @"data\gametext8.bsa", @"data\gametext7.bsa", @"data\gametext6.bsa", @"data\gametext5.bsa", @"data\gametext4.bsa", @"data\gametext3.bsa", @"data\gametext2.bsa", @"data\gametext1.bsa", @"data\gamemesh3.bsa", @"data\gamemesh2.bsa", @"data\gamemesh1.bsa", @"data\gamecomm.bsa", @"data\frostfall.esp", @"data\frostfall.bsa", @"data\frostfall-ws.esp", @"data\frostfall-ws.bsa", @"data\footprints.esp", @"data\footprints.bsa", @"data\followeroutfits.esp", @"data\followeroutfits.bsa", @"data\follower commentary.esp", @"data\follower commentary.bsa", @"data\fnis.esp", @"data\fnis.bsa", @"data\fnis.ini", @"data\florarespawnfix.esp", @"data\florarespawnfix.bsa", @"data\falskaar.esp", @"data\falskaar.bsa", @"data\eyeshairs.esp", @"data\eyeshairs.bsa", @"data\enhancedlightsfx.esp", @"data\enhancedlightsfx.bsa", @"data\enhanced blood.esp", @"data\enhanced blood.bsa", @"data\enb vision.esp", @"data\enb vision.bsa", @"data\dual wield parrying.esp", @"data\dual wield parrying.bsa", @"data\dual sheath redux.esp", @"data\dual sheath redux.bsa", @"data\dual sheath redux patch.esp", @"data\dragonborn.esm", @"data\disablefasttravel.esp", @"data\disablefasttravel.bsa", @"data\destructiblebottles.esp", @"data\destructiblebottles.bsa", @"data\deadlyspellimpacts.esp", @"data\deadlyspellimpacts.bsa", @"data\dawnguard.esm", @"data\cutting room floor.esp", @"data\cutting room floor.bsa", @"data\customizable camera.esp", @"data\customizable camera.bsa", @"data\constantraretrees.bsa", @"data\constantraretrees.esp", @"data\constantlushtrees.bsa", @"data\constantlushtrees.esp", @"data\coinpurse.esp", @"data\coinpurse.bsa", @"data\ccfwaf.esp", @"data\ccfwaf.bsa", @"data\campfire.esm", @"data\campfire.bsa", @"data\camerascripter.esp", @"data\camerascripter.bsa", @"data\book covers skyrim.esp", @"data\book covers skyrim.bsa", @"data\blacksmith chests.esp", @"data\blacksmith chests.bsa", @"data\bfseffects.esp", @"data\bfseffects.bsa", @"data\audiooverhaulskyrim.esp", @"data\audiooverhaulskyrim.bsa", @"data\armorweapon.esp", @"data\armorweapon.bsa", @"data\amatteroftime.esp", @"data\amatteroftime.bsa", @"data\alwayspickupbooks.esp", @"data\alwayspickupbooks.bsa", @"data\alternatestart.esp", @"data\alternatestart.bsa", @"data\ahzmorehud.esp", @"data\ahzmorehud.bsa", @"data\additemmenu2.esp", @"data\additemmenu2.bsa", @"data\acquisitivesoulgem.esp", @"data\acquisitivesoulgem.bsa", @"d3d9.dll", @"binkw32.dll", @"atimgpud.dll" };
        static List<string> IgnoreFoldersList = new List<string> { @"_programs", @"data", @"data\camerascripts", @"data\meshes", @"data\meshes\0sa", @"data\meshes\0sp", @"data\meshes\actors", @"data\meshes\actors\character", @"data\meshes\actors\character\animations", @"data\meshes\actors\character\animations\0sex_0mf_d", @"data\meshes\actors\character\animations\0sex_0mf_k", @"data\meshes\actors\character\animations\0sex_0mf_m", @"data\meshes\actors\character\animations\0sex_0mf_s", @"data\meshes\actors\character\animations\0sex_0mf_u", @"data\meshes\actors\character\animations\0sex_emf_a", @"data\meshes\actors\character\animations\_esg_0er_f", @"data\meshes\actors\character\animations\_esg_0er_m", @"data\meshes\actors\character\animations\fnisbase", @"data\meshes\actors\character\behaviors", @"data\meshes\actors\character\character assets female", @"data\meshes\actors\character\character assets", @"data\meshes\actors\character\characters female", @"data\meshes\actors\character\characters", @"data\meshes\armor", @"data\meshes\armor\chesko", @"data\meshes\armor\naked", @"data\meshes\armor\weaponsling", @"data\meshes\clothes", @"data\meshes\clothes\cloaks", @"data\meshes\clothes\hdt test earring", @"data\meshes\clothes\horsecloak", @"data\meshes\hair", @"data\meshes\hair\clark", @"data\meshes\hair\fuse00hair", @"data\meshes\hair\havok physx", @"data\meshes\hair\hdt untitled hairs", @"data\meshes\hair\hhairstyles", @"data\meshes\hair\ks hairdo's", @"data\meshes\hair\skyrim hdt hair", @"data\meshes\hair\yoo", @"data\scripts", @"data\skse", @"data\skse\plugins", @"data\skse\plugins\campfiredata", @"data\skse\plugins\chargen", @"data\skse\plugins\frostfalldata", @"data\skse\plugins\wearablelanternsdata", @"data\skyproc patchers", @"data\skyproc patchers\dual sheath redux patch", @"data\tools", @"data\tools\generatefnis_for_users", @"data\tools\generatefnis_for_users\languages", @"data\tools\generatefnis_for_users\templates", @"data\tools\generatefnis_for_users\temporary_logs", @"enbseries", @"logs", @"skyrim", @"skyrim\cpfiles", @"skyrim\enb", @"skyrim\masterlist" };
        static List<string> IngoredSearchFoldersList = new List<string> { @"_programs", @"data\camerascripts", @"data\meshes\0sa", @"data\meshes\0sp", @"data\meshes\actors\character\animations\0sex_0mf_d", @"data\meshes\actors\character\animations\0sex_0mf_k", @"data\meshes\actors\character\animations\0sex_0mf_m", @"data\meshes\actors\character\animations\0sex_0mf_s", @"data\meshes\actors\character\animations\0sex_0mf_u", @"data\meshes\actors\character\animations\0sex_emf_a", @"data\meshes\actors\character\animations\_esg_0er_f", @"data\meshes\actors\character\animations\_esg_0er_m", @"data\meshes\actors\character\animations\fnisbase", @"data\meshes\actors\character\behaviors", @"data\meshes\armor\chesko", @"data\meshes\armor\naked", @"data\meshes\armor\weaponsling", @"data\meshes\clothes\cloaks", @"data\meshes\clothes\hdt test earring", @"data\meshes\clothes\horsecloak", @"data\meshes\hair\clark", @"data\meshes\hair\fuse00hair", @"data\meshes\hair\havok physx", @"data\meshes\hair\hdt untitled hairs", @"data\meshes\hair\hhairstyles", @"data\meshes\hair\ks hairdo's", @"data\meshes\hair\skyrim hdt hair", @"data\meshes\hair\yoo", @"data\skse\plugins\campfiredata", @"data\skse\plugins\chargen", @"data\skse\plugins\frostfalldata", @"data\skse\plugins\wearablelanternsdata", @"data\tools\generatefnis_for_users\languages", @"data\tools\generatefnis_for_users\templates", @"enbseries", @"skyrim\cpfiles", @"skyrim\enb", @"skyrim\masterlist" };
        public static void clearGameFolder()
        {
            CustomIgnoreList.Clear();
            if (File.Exists(FormMain.pathIgnoreINI))
            {
                CustomIgnoreList.AddRange(File.ReadAllLines(FormMain.pathIgnoreINI));
            }
            if (Directory.Exists(FormMain.pathGameFolder))
            {
                clearCurrentFolder("");
                searthAllForders(FormMain.pathGameFolder);
                emptyFolder(FormMain.pathGameFolder);
            }
        }
        static void searthAllForders(string startLocation)
        {
            if (Directory.Exists(startLocation))
            {
                foreach (string line in Directory.EnumerateDirectories(startLocation))
                {
                    string folderName = line.Remove(0, FormMain.pathGameFolder.Length);
                    if (folderName.Length > 0)
                    {
                        if (!IngoredSearchFoldersList.Contains(folderName, StringComparer.OrdinalIgnoreCase) && !CustomIgnoreList.Contains(folderName, StringComparer.OrdinalIgnoreCase))
                        {
                            searthAllForders(line);
                            clearCurrentFolder(folderName);
                        }
                    }
                }
            }
        }
        static void clearCurrentFolder(string clearpath)
        {
            if (Directory.Exists(FormMain.pathGameFolder + clearpath))
            {
                foreach (string line in Directory.EnumerateFiles(FormMain.pathGameFolder + clearpath))
                {
                    string fileName = line.Remove(0, FormMain.pathGameFolder.Length);
                    if (!IgnoreFilesList.Contains(fileName, StringComparer.OrdinalIgnoreCase) && !CustomIgnoreList.Contains(fileName, StringComparer.OrdinalIgnoreCase))
                    {
                        FuncFiles.deleteAny(line);
                    }
                }
                foreach (string line in Directory.EnumerateDirectories(FormMain.pathGameFolder + clearpath))
                {
                    string dirName = line.Remove(0, FormMain.pathGameFolder.Length);
                    if (!IgnoreFoldersList.Contains(dirName, StringComparer.OrdinalIgnoreCase) && !CustomIgnoreList.Contains(dirName, StringComparer.OrdinalIgnoreCase))
                    {
                        FuncFiles.deleteAny(line);
                    }
                }
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        public static void emptyFolder(string path)
        {
            if (Directory.Exists(path))
            {
                foreach (string line in Directory.GetDirectories(path))
                {
                    emptyFolder(line);
                    if (Directory.GetFiles(line).Length == 0 && Directory.GetDirectories(line).Length == 0)
                    {
                        FuncFiles.deleteAny(line);
                    }
                }
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        public static void removeENB()
        {
            foreach (string line in new string[] { @"data\enb vision.bsa", @"data\enb vision.esp", "eed_verasansmono.bmp", "elep additional shaders", "enbinjector.exe", "enbpalettes", "enhancedenbdiagnostics.fxh", "fxaa_tool.exe", "fixforbrightobjects.txt", "smaa.fx", "smaa.h", "smaa_dx11.fx", "shader functions", "sweetfx", "sweetfx_d3d9.dll", "sweetfx_preset.txt", "sweetfx_settings.txt", "_locationweather.ini", "_mist_anchors.xml", "_sample_enbraindrops", "_weatherlist.ini", "common.fxh", "d3d9.dll", "d3d9.fx", "d3d9sffiles.dll", "d3d9_fxaa.dll", "d3d9_sffiles.dll", "d3d9_sfx.dll", "d3d9_sfx_fxaa.dll", "d3d9_sfx_smaa.dll", "d3d9_sharpen.dll", "d3d9_sweetffiles.dll", "d3d9_smaa.dll", "d3d9injffiles.dll", "d3d9orig.dll", "d3d9swe.dll", "defaultlut.png", "dxgi.dll", "dxgi.fx", "effect.txt", "effect.txt.ini", "enbbloom.fx", "enbbloom.fx.ini", "enbbloom.fx.rar", "enbdefs.fx", "enbdirt.bmp", "enbdirt.tga", "enbeffect.ffiles.ini", "enbeffect.fx", "enbeffect.fx.ini", "enbeffectprepass.fx", "enbeffectprepass.fx.ini", "enbeffectxx.fx.ini", "enbfontunicode.png", "enbfrost.bmp", "enbhelper.dll", "enbhost.exe", "enbinjector.ini", "enblens.fx", "enblens.fx.ini", "enblens1.fx", "enblensmask.bmp", "enblensmask.png", "enblensmask.tga", "enblocal.ini", "enblocalization.xml", "enbpalette.bmp", "enbpalette.png", "enbraindrops.tga", "enbseries", "enbseries.ini", "enbspectrum.bmp", "enbsunsprite.fx", "enbsunsprite.fx.ini", "enbsunsprite.tga", "enbweather.bmp", "injfx_settings.h", "injfx_shaders", "injector.ini", "shader.fx", "shift.dll", "sweetfx_d3d9.dll", "technique.fxh", "volumetric_mist_anchors.xml" })
            {
                FuncFiles.deleteAny(FormMain.pathGameFolder + line);
            }
        }
    }
}