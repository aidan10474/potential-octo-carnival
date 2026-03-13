using ExecuteQueryCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using CSGenio.persistence;
using CSGenio.business;
using CSGenio.framework;
using Quidgest.Persistence.GenericQuery;
using Quidgest.Persistence;

namespace CSGenio.business
{
    public class ReindexFunctions
    {
        public PersistentSupport sp { get; set; }
        public User user { get; set; }
        public bool Zero { get; set; }

        public ReindexFunctions(PersistentSupport sp, User user, bool Zero = false) {
            this.sp = sp;
            this.user = user;
            this.Zero = Zero;
        }   

        public void DeleteInvalidRows(CancellationToken cToken) {
            List<int> zzstateToRemove = new List<int> { 1, 11 };
            DataMatrix dm;
            sp.openConnection();

            /* --- PRJMEM --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAmem.FldCodmem)
                .From(CSGenioAmem.AreaMEM)
                .Where(CriteriaSet.And().In(CSGenioAmem.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAmem model = new CSGenioAmem(user);
                model.ValCodmem = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- PRJPLAYER --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAplayer.FldCodplayers)
                .From(CSGenioAplayer.AreaPLAYER)
                .Where(CriteriaSet.And().In(CSGenioAplayer.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAplayer model = new CSGenioAplayer(user);
                model.ValCodplayers = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- UserLogin --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioApsw.FldCodpsw)
                .From(CSGenioApsw.AreaPSW)
                .Where(CriteriaSet.And().In(CSGenioApsw.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioApsw model = new CSGenioApsw(user);
                model.ValCodpsw = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- AsyncProcess --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAs_apr.FldCodascpr)
                .From(CSGenioAs_apr.AreaS_APR)
                .Where(CriteriaSet.And().In(CSGenioAs_apr.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAs_apr model = new CSGenioAs_apr(user);
                model.ValCodascpr = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- NotificationEmailSignature --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAs_nes.FldCodsigna)
                .From(CSGenioAs_nes.AreaS_NES)
                .Where(CriteriaSet.And().In(CSGenioAs_nes.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAs_nes model = new CSGenioAs_nes(user);
                model.ValCodsigna = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- NotificationMessage --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAs_nm.FldCodmesgs)
                .From(CSGenioAs_nm.AreaS_NM)
                .Where(CriteriaSet.And().In(CSGenioAs_nm.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAs_nm model = new CSGenioAs_nm(user);
                model.ValCodmesgs = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- PRJSKILL --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAskill.FldCodskill)
                .From(CSGenioAskill.AreaSKILL)
                .Where(CriteriaSet.And().In(CSGenioAskill.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAskill model = new CSGenioAskill(user);
                model.ValCodskill = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- PRJTEAM --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAteam.FldCodteam)
                .From(CSGenioAteam.AreaTEAM)
                .Where(CriteriaSet.And().In(CSGenioAteam.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAteam model = new CSGenioAteam(user);
                model.ValCodteam = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- PRJPLAYER_TEAM --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAplayer_team.FldCodplayer_team)
                .From(CSGenioAplayer_team.AreaPLAYER_TEAM)
                .Where(CriteriaSet.And().In(CSGenioAplayer_team.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAplayer_team model = new CSGenioAplayer_team(user);
                model.ValCodplayer_team = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- AsyncProcessArgument --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAs_arg.FldCodargpr)
                .From(CSGenioAs_arg.AreaS_ARG)
                .Where(CriteriaSet.And().In(CSGenioAs_arg.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAs_arg model = new CSGenioAs_arg(user);
                model.ValCodargpr = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- AsyncProcessAttachments --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAs_pax.FldCodpranx)
                .From(CSGenioAs_pax.AreaS_PAX)
                .Where(CriteriaSet.And().In(CSGenioAs_pax.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAs_pax model = new CSGenioAs_pax(user);
                model.ValCodpranx = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- UserAuthorization --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAs_ua.FldCodua)
                .From(CSGenioAs_ua.AreaS_UA)
                .Where(CriteriaSet.And().In(CSGenioAs_ua.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAs_ua model = new CSGenioAs_ua(user);
                model.ValCodua = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- PRJSKILL_PLAYER --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAskill_player.FldCodskill_player)
                .From(CSGenioAskill_player.AreaSKILL_PLAYER)
                .Where(CriteriaSet.And().In(CSGenioAskill_player.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAskill_player model = new CSGenioAskill_player(user);
                model.ValCodskill_player = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- PRJSTATS --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAstats.FldCodstats)
                .From(CSGenioAstats.AreaSTATS)
                .Where(CriteriaSet.And().In(CSGenioAstats.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAstats model = new CSGenioAstats(user);
                model.ValCodstats = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                
            
            //Hard Coded Tabels
            //These can be directly removed

            /* --- PRJmem --- */
            sp.Execute(new DeleteQuery()
                .Delete("PRJmem")
                .Where(CriteriaSet.And().In("PRJmem", "ZZSTATE", zzstateToRemove)));
                
            /* --- PRJcfg --- */
            sp.Execute(new DeleteQuery()
                .Delete("PRJcfg")
                .Where(CriteriaSet.And().In("PRJcfg", "ZZSTATE", zzstateToRemove)));
                
            /* --- PRJlstusr --- */
            sp.Execute(new DeleteQuery()
                .Delete("PRJlstusr")
                .Where(CriteriaSet.And().In("PRJlstusr", "ZZSTATE", zzstateToRemove)));
                
            /* --- PRJlstcol --- */
            sp.Execute(new DeleteQuery()
                .Delete("PRJlstcol")
                .Where(CriteriaSet.And().In("PRJlstcol", "ZZSTATE", zzstateToRemove)));
                
            /* --- PRJlstren --- */
            sp.Execute(new DeleteQuery()
                .Delete("PRJlstren")
                .Where(CriteriaSet.And().In("PRJlstren", "ZZSTATE", zzstateToRemove)));
                
            /* --- PRJusrwid --- */
            sp.Execute(new DeleteQuery()
                .Delete("PRJusrwid")
                .Where(CriteriaSet.And().In("PRJusrwid", "ZZSTATE", zzstateToRemove)));
                
            /* --- PRJusrcfg --- */
            sp.Execute(new DeleteQuery()
                .Delete("PRJusrcfg")
                .Where(CriteriaSet.And().In("PRJusrcfg", "ZZSTATE", zzstateToRemove)));
                
            /* --- PRJusrset --- */
            sp.Execute(new DeleteQuery()
                .Delete("PRJusrset")
                .Where(CriteriaSet.And().In("PRJusrset", "ZZSTATE", zzstateToRemove)));
                
            /* --- PRJwkfact --- */
            sp.Execute(new DeleteQuery()
                .Delete("PRJwkfact")
                .Where(CriteriaSet.And().In("PRJwkfact", "ZZSTATE", zzstateToRemove)));
                
            /* --- PRJwkfcon --- */
            sp.Execute(new DeleteQuery()
                .Delete("PRJwkfcon")
                .Where(CriteriaSet.And().In("PRJwkfcon", "ZZSTATE", zzstateToRemove)));
                
            /* --- PRJwkflig --- */
            sp.Execute(new DeleteQuery()
                .Delete("PRJwkflig")
                .Where(CriteriaSet.And().In("PRJwkflig", "ZZSTATE", zzstateToRemove)));
                
            /* --- PRJwkflow --- */
            sp.Execute(new DeleteQuery()
                .Delete("PRJwkflow")
                .Where(CriteriaSet.And().In("PRJwkflow", "ZZSTATE", zzstateToRemove)));
                
            /* --- PRJnotifi --- */
            sp.Execute(new DeleteQuery()
                .Delete("PRJnotifi")
                .Where(CriteriaSet.And().In("PRJnotifi", "ZZSTATE", zzstateToRemove)));
                
            /* --- PRJprmfrm --- */
            sp.Execute(new DeleteQuery()
                .Delete("PRJprmfrm")
                .Where(CriteriaSet.And().In("PRJprmfrm", "ZZSTATE", zzstateToRemove)));
                
            /* --- PRJscrcrd --- */
            sp.Execute(new DeleteQuery()
                .Delete("PRJscrcrd")
                .Where(CriteriaSet.And().In("PRJscrcrd", "ZZSTATE", zzstateToRemove)));
                
            /* --- docums --- */
            sp.Execute(new DeleteQuery()
                .Delete("docums")
                .Where(CriteriaSet.And().In("docums", "ZZSTATE", zzstateToRemove)));
                
            /* --- PRJpostit --- */
            sp.Execute(new DeleteQuery()
                .Delete("PRJpostit")
                .Where(CriteriaSet.And().In("PRJpostit", "ZZSTATE", zzstateToRemove)));
                
            /* --- hashcd --- */
            sp.Execute(new DeleteQuery()
                .Delete("hashcd")
                .Where(CriteriaSet.And().In("hashcd", "ZZSTATE", zzstateToRemove)));
                
            /* --- PRJalerta --- */
            sp.Execute(new DeleteQuery()
                .Delete("PRJalerta")
                .Where(CriteriaSet.And().In("PRJalerta", "ZZSTATE", zzstateToRemove)));
                
            /* --- PRJaltent --- */
            sp.Execute(new DeleteQuery()
                .Delete("PRJaltent")
                .Where(CriteriaSet.And().In("PRJaltent", "ZZSTATE", zzstateToRemove)));
                
            /* --- PRJtalert --- */
            sp.Execute(new DeleteQuery()
                .Delete("PRJtalert")
                .Where(CriteriaSet.And().In("PRJtalert", "ZZSTATE", zzstateToRemove)));
                
            /* --- PRJdelega --- */
            sp.Execute(new DeleteQuery()
                .Delete("PRJdelega")
                .Where(CriteriaSet.And().In("PRJdelega", "ZZSTATE", zzstateToRemove)));
                
            /* --- PRJTABDINAMIC --- */
            sp.Execute(new DeleteQuery()
                .Delete("PRJTABDINAMIC")
                .Where(CriteriaSet.And().In("PRJTABDINAMIC", "ZZSTATE", zzstateToRemove)));
                
            /* --- UserAuthorization --- */
            sp.Execute(new DeleteQuery()
                .Delete("UserAuthorization")
                .Where(CriteriaSet.And().In("UserAuthorization", "ZZSTATE", zzstateToRemove)));
                
            /* --- PRJaltran --- */
            sp.Execute(new DeleteQuery()
                .Delete("PRJaltran")
                .Where(CriteriaSet.And().In("PRJaltran", "ZZSTATE", zzstateToRemove)));
                
            /* --- PRJworkflowtask --- */
            sp.Execute(new DeleteQuery()
                .Delete("PRJworkflowtask")
                .Where(CriteriaSet.And().In("PRJworkflowtask", "ZZSTATE", zzstateToRemove)));
                
            /* --- PRJworkflowprocess --- */
            sp.Execute(new DeleteQuery()
                .Delete("PRJworkflowprocess")
                .Where(CriteriaSet.And().In("PRJworkflowprocess", "ZZSTATE", zzstateToRemove)));
                

            sp.closeConnection();
        }





        // USE /[MANUAL RDX_STEP]/
    }
}