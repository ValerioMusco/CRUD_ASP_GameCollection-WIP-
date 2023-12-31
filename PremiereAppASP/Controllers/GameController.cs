﻿using Microsoft.AspNetCore.Mvc;
using PremiereAppASP.Models;
using PremiereAppASP.Services;
using System.Diagnostics;

namespace PremiereAppASP.Controllers {

    public class GameController : Controller {

        //private readonly ILogger<GameController> _logger;

        private readonly IGameDbService _gameDbService;

        public GameController( IGameDbService gameDbService ) {
            _gameDbService = gameDbService;
        }


        //public GameController( ILogger<GameController> logger ) {
        //    _logger = logger;
        //}

        public IActionResult Index() {
            return View( _gameDbService.GetAll() );
        }

        public IActionResult Details( int id ) {
            return View( _gameDbService.GetById( id ) );
        }

        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public IActionResult Create( Games g ) {

            if( g != null )
                _gameDbService.Create( g );
            return RedirectToAction( "Index" );
        }

        public IActionResult Delete( int? id ) {

            if( id != null )
                _gameDbService.Delete( (int)id );
            return RedirectToAction( "Index" );
        }

        public IActionResult Edit( int id ) {


            return View( _gameDbService.GetById( id ) );
        }

        [HttpPost]
        public IActionResult Edit( Games g ) {

            if( g != null )
                _gameDbService.Update( g );

            return RedirectToAction( "Index" );
        }

        [ResponseCache( Duration = 0, Location = ResponseCacheLocation.None, NoStore = true )]
        public IActionResult Error() {
            return View( new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier } );
        }
    }
}