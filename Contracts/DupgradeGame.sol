// SPDX-License-Identifier: MIT
pragma solidity ^0.8.0;

contract DupgradeGame {
    struct Player {
        uint256 swordLevel;
        uint256 armorLevel;
        uint256 bossKills;
        uint256 lastBossKillTimestamp;
    }

    DupgradeToken public dupgradeToken;
    uint256 public startingTokenAmount = 1000 * 10 ** 18;
    uint256 public totalNFTs = 100;

    mapping(address => Player) public players;
    mapping(uint256 => address) public nftOwners;

    event BossKilled(address indexed player, uint256 swordLevel, uint256 armorLevel);

    modifier onlyPlayer() {
        require(players[msg.sender].swordLevel > 0 || players[msg.sender].armorLevel > 0, "You need to start the game first");
        _;
    }

    constructor(DupgradeToken _dupgradeToken) {
        dupgradeToken = _dupgradeToken;
    }

    function startGame() external {
        require(players[msg.sender].swordLevel == 0 && players[msg.sender].armorLevel == 0, "Game already started");

        players[msg.sender].swordLevel = 1;
        players[msg.sender].armorLevel = 1;

        dupgradeToken.transfer(msg.sender, startingTokenAmount);
    }

    function upgradeSword() external onlyPlayer {
        uint256 upgradeCost = players[msg.sender].swordLevel * 100; // Placeholder cost formula
        require(dupgradeToken.balanceOf(msg.sender) >= upgradeCost, "Insufficient tokens");

        players[msg.sender].swordLevel++;
        dupgradeToken.transferFrom(msg.sender, address(this), upgradeCost);
    }

    function upgradeArmor() external onlyPlayer {
        uint256 upgradeCost = players[msg.sender].armorLevel * 100; // Placeholder cost formula
        require(dupgradeToken.balanceOf(msg.sender) >= upgradeCost, "Insufficient tokens");

        players[msg.sender].armorLevel++;
        dupgradeToken.transferFrom(msg.sender, address(this), upgradeCost);
    }

    function killBoss() external onlyPlayer {
        // Placeholder logic for killing the boss
        uint256 bossPower = players[msg.sender].swordLevel + players[msg.sender].armorLevel;
        require(bossPower >= 10, "You need to upgrade your equipment first");

        players[msg.sender].bossKills++;
        players[msg.sender].lastBossKillTimestamp = block.timestamp;

        uint256 nftId = players[msg.sender].bossKills % totalNFTs;
        address currentNftOwner = nftOwners[nftId];

        // If the NFT hasn't been claimed yet or the player's boss kills are higher than the current owner's boss kills, they can claim the NFT
        if (currentNftOwner == address(0) || players[msg.sender].bossKills > players[currentNftOwner].bossKills) {
            nftOwners[nftId] = msg.sender;
        }

        emit BossKilled(msg.sender, players[msg.sender].swordLevel, players[msg.sender].armorLevel);
    }

    function getNFTOwner(uint256 nftId) external view returns (address) {
        return nftOwners[nftId];
    }
}
