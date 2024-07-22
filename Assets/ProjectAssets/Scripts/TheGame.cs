using System;
using UnityEngine;
using MyInjection;
using Game.World;
using Game.Core.Systems;
using Managers;
using Reusing;
using UnityEditor;

public class TheGame : MonoBehaviour
{
    [SerializeField] GameSystemsBridge _gameSystemsBridge;
    [SerializeField] Transform _objectsRoot;
    [SerializeField] PoolsContainer _poolsContainer;
    [SerializeField] MenuWindow menuWindow;
    [SerializeField] HUDView _hudView;
    static IoC _ioc;
    IWorldManager _worldManager;
    
    public void Awake()
    {
        _worldManager = new WorldManager();
        _gameSystemsBridge.Bind(_worldManager.gameSystemsContainer);
        _worldManager.onGameOver += OnGameOver;
        _worldManager.onEscape += OnEscapeMenu;
        _ioc = new IoC();
        _ioc.RegisterInstance(typeof(IConfigManager), new ConfigManager());
        _ioc.RegisterInstance(typeof(IPoolManager), new PoolManager(_poolsContainer));
        _ioc.RegisterInstance(typeof(IInputManager), new InputManager());
        _ioc.RegisterInstance(typeof(IPrefabManager), new PrefabManager(transform, "ObjectsPrefabs/"));
        _ioc.RegisterInstance(typeof(IWorldManager), _worldManager);
        menuWindow.onStartGame += StartGameLoop;
        menuWindow.onResume += ResumeGameLoop;
        menuWindow.onExitDesctop += ExitDesktop;
        menuWindow.ShowNew();
    }

    void StartGameLoop()
    {
        var gameSystemsContainer = new GameSystems();
        gameSystemsContainer.RegisterSystem(_ioc.InstantiateWithDepencies<PlayerCreateSystem>());
        gameSystemsContainer.RegisterSystem(_ioc.InstantiateWithDepencies<PlayerInputSystem>());
        gameSystemsContainer.RegisterSystem(_ioc.InstantiateWithDepencies<VisualizeSystem>(_objectsRoot));
        gameSystemsContainer.RegisterSystem(_ioc.InstantiateWithDepencies<AsteroidGenerationSystem>());
        gameSystemsContainer.RegisterSystem(_ioc.InstantiateWithDepencies<EnemiesGeneratingSystem>());
        gameSystemsContainer.RegisterSystem(_ioc.InstantiateWithDepencies<AsteroidsMovingSystem>());
        gameSystemsContainer.RegisterSystem(_ioc.InstantiateWithDepencies<EnemyMovingSystem>());
        gameSystemsContainer.RegisterSystem(_ioc.InstantiateWithDepencies<PlayerMoveSystem>());
        gameSystemsContainer.RegisterSystem(_ioc.InstantiateWithDepencies<CollisionDetectSystem>());
        gameSystemsContainer.RegisterSystem(_ioc.InstantiateWithDepencies<HealthSystem>());
        gameSystemsContainer.RegisterSystem(_ioc.InstantiateWithDepencies<ShotEventHandleSystem>());
        gameSystemsContainer.RegisterSystem(_ioc.InstantiateWithDepencies<HUDVisualizeSystem>(_hudView));
        gameSystemsContainer.Init();
        _worldManager.gameSystemsContainer.Value = gameSystemsContainer;
        menuWindow.Hide();
    }
    
    void ResumeGameLoop()
    {
        _worldManager.Resume();
        menuWindow.Hide();
    }

    void OnEscapeMenu()
    {
        menuWindow.ShowResume();
    }

    void OnGameOver()
    {
        menuWindow.ShowReplay(_worldManager.finalScore);
    }

    void ExitDesktop()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }


}


