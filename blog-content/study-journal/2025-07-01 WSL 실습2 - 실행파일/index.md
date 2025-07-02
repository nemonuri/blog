---
alias: wsl-practice2-install-apps
subindex: 2
---

# WSL 실습2 - 설치 및 맛보기

## 학습 목표

- Linux 의 //usr/bin 디렉터리에 대해 알아본다.
- wget 으로 llvm 패키지를 Ubuntu 에 설치하는 방법에 대해 알아본다.
- 설치된 llvm 관련 프로그램들을 정상적으로 실행할 수 있도록 설정하는 방법에 대해 알아본다.

## 미리 설치된 실행파일 확인하기

- 막 설치한 Linux Distro의 실행파일들은 주로 `//usr/bin` 안에 모여 있다.
- 다음 명령어를 실행해 `//usr/bin` 안의 실행파일들을 살펴보자.

```shell
cd //usr/bin
ls
```

```
 NF                                   gtk-builder-tool                   routel
 X11                                  gtk-encode-symbolic-svg            rrsync
'['                                   gtk-launch                         rsync
 aa-enabled                           gtk-query-settings                 rsync-ssl
 aa-exec                              gtk-update-icon-cache              rtstat
 aa-features-abi                      gunzip                             run-one
 add-apt-repository                   gzexe                              run-one-constantly
 addpart                              gzip                               run-one-until-failure
 addr2line                            h2ph                               run-one-until-success
 apport-bug                           h2xs                               run-parts
 apport-cli                           hardlink                           run-this-one
 apport-collect                       hd                                 runcon
 apport-unpack                        head                               rview
 appstreamcli                         helpztags                          rvim
 apropos                              hexdump                            savelog
 apt                                  hostid                             scalar
 apt-add-repository                   hostname                           scp
 apt-cache                            hostnamectl                        screendump
 apt-cdrom                            hwe-support-status                 script
 apt-config                           i386                               scriptlive
 apt-extracttemplates                 iconv                              scriptreplay
 apt-ftparchive                       id                                 sdiff
 apt-get                              info                               sed
 apt-key                              infobrowser                        select-editor
 apt-mark                             infocmp                            sensible-browser
 apt-sortpkgs                         infotocap                          sensible-editor
 ar                                   install                            sensible-pager
 arch                                 install-info                       sensible-terminal
 as                                   instmodsh                          seq
 automat-visualize3                   ionice                             session-migration
 awk                                  ip                                 setarch
 b2sum                                ipcmk                              setfont
 base32                               ipcrm                              setkeycodes
 base64                               ipcs                               setleds
 basename                             ischroot                           setlogcons
 basenc                               join                               setmetamode
 bash                                 journalctl                         setpriv
 bashbug                              json-patch-jsondiff                setsid
 bc                                   json_pp                            setterm
 broadwayd                            jsondiff                           setupcon
 busctl                               jsonpatch                          sftp
 byobu                                jsonpointer                        sg
 byobu-config                         jsonschema                         sh
 byobu-ctrl-a                         kbd_mode                           sha1sum
 byobu-disable                        kbdinfo                            sha224sum
 byobu-disable-prompt                 kbxutil                            sha256sum
 byobu-enable                         keep-one-running                   sha384sum
 byobu-enable-prompt                  kernel-install                     sha512sum
 byobu-export                         kill                               shasum
 byobu-janitor                        killall                            showconsolefont
 byobu-keybindings                    kmod                               showkey
 byobu-launch                         landscape-broker                   shred
 byobu-launcher                       landscape-client                   shuf
 byobu-launcher-install               landscape-config                   size
 byobu-launcher-uninstall             landscape-manager                  skill
 byobu-layout                         landscape-monitor                  slabtop
 byobu-prompt                         landscape-package-changer          sleep
 byobu-quiet                          landscape-package-reporter         slogin
 byobu-reconnect-sockets              landscape-release-upgrader         snap
 byobu-screen                         landscape-sysinfo                  snapctl
 byobu-select-backend                 last                               snapfuse
 byobu-select-profile                 lastb                              snice
 byobu-select-session                 lastlog                            soelim
 byobu-shell                          lcf                                sort
 byobu-silent                         ld                                 splain
 byobu-status                         ld.bfd                             split
 byobu-status-detail                  ld.gold                            splitfont
 byobu-tmux                           ld.so                              sqfscat
 byobu-ugraph                         ldd                                sqfstar
 byobu-ulevel                         less                               ss
 c++filt                              lessecho                           ssh
 c_rehash                             lessfile                           ssh-add
 captoinfo                            lesskey                            ssh-agent
 cat                                  lesspipe                           ssh-argv0
 catman                               lexgrog                            ssh-copy-id
 cftp3                                libnetcfg                          ssh-keygen
 chage                                link                               ssh-keyscan
 chardet                              linux32                            stat
 chardetect                           linux64                            stdbuf
 chattr                               ln                                 streamzip
 chcon                                lnstat                             strings
 chfn                                 loadkeys                           strip
 chgrp                                loadunimap                         stty
 chmod                                locale                             su
 choom                                locale-check                       sudo
 chown                                localectl                          sudoedit
 chrt                                 localedef                          sudoreplay
 chsh                                 logger                             sum
 chvt                                 login                              sync
 ckbcomp                              loginctl                           systemctl
 ckeygen3                             logname                            systemd
 cksum                                look                               systemd-ac-power
 clear                                ls                                 systemd-analyze
 clear_console                        lsattr                             systemd-ask-password
 cloud-id                             lsb_release                        systemd-cat
 cloud-init                           lsblk                              systemd-cgls
 cloud-init-per                       lscpu                              systemd-cgtop
 cmp                                  lshw                               systemd-confext
 codepage                             lsipc                              systemd-creds
 col                                  lslocks                            systemd-cryptenroll
 col1                                 lslogins                           systemd-cryptsetup
 col2                                 lsmem                              systemd-delta
 col3                                 lsmod                              systemd-detect-virt
 col4                                 lsns                               systemd-escape
 col5                                 lsof                               systemd-firstboot
 col6                                 lspgpot                            systemd-hwdb
 col7                                 lzcat                              systemd-id128
 col8                                 lzcmp                              systemd-inhibit
 col9                                 lzdiff                             systemd-machine-id-setup
 colcrt                               lzegrep                            systemd-mount
 colrm                                lzfgrep                            systemd-notify
 column                               lzgrep                             systemd-path
 comm                                 lzless                             systemd-repart
 conch3                               lzma                               systemd-run
 corelist                             lzmainfo                           systemd-socket-activate
 cp                                   lzmore                             systemd-stdio-bridge
 cpan                                 mailmail3                          systemd-sysext
 cpan5.38-x86_64-linux-gnu            man                                systemd-sysusers
 crontab                              man-recode                         systemd-tmpfiles
 csplit                               mandb                              systemd-tty-ask-password-agent
 ctail                                manifest                           systemd-umount
 ctstat                               manpath                            tabs
 curl                                 mapscrn                            tac
 cut                                  markdown-it                        tail
 cvtsudoers                           mawk                               tar
 dash                                 mcookie                            taskset
 date                                 md5sum                             tbl
 dbus-cleanup-sockets                 md5sum.textutils                   tee
 dbus-daemon                          mesa-overlay-control.py            tempfile
 dbus-launch                          mesg                               test
 dbus-monitor                         migrate-pubring-from-classic-gpg   tic
 dbus-run-session                     mk_modmap                          time
 dbus-send                            mkdir                              timedatectl
 dbus-update-activation-environment   mkfifo                             timeout
 dbus-uuidgen                         mknod                              tkconch3
 dd                                   mksquashfs                         tload
 deallocvt                            mktemp                             tmux
 deb-systemd-helper                   more                               toe
 deb-systemd-invoke                   mount                              top
 debconf                              mountpoint                         touch
 debconf-apt-progress                 mv                                 tput
 debconf-communicate                  namei                              tr
 debconf-copydb                       nano                               trial3
 debconf-escape                       nawk                               troff
 debconf-set-selections               nc                                 true
 debconf-show                         nc.openbsd                         truncate
 debian-distro-info                   neqn                               tset
 delpart                              netcat                             tsort
 df                                   networkctl                         tty
 dh_bash-completion                   networkd-dispatcher                twist3
 dh_installxmlcatalogs                newgrp                             twistd3
 diff                                 ngettext                           tzselect
 diff3                                nice                               ua
 dir                                  nisdomainname                      ubuntu-advantage
 dircolors                            nl                                 ubuntu-bug
 dirmngr                              nm                                 ubuntu-distro-info
 dirmngr-client                       nohup                              ubuntu-security-status
 dirname                              nproc                              ucf
 distro-info                          nroff                              ucfq
 dmesg                                nsenter                            ucfr
 dnsdomainname                        nstat                              uclampset
 do-release-upgrade                   numfmt                             udevadm
 domainname                           objcopy                            ul
 dpkg                                 objdump                            umount
 dpkg-deb                             od                                 uname
 dpkg-divert                          oem-getlogs                        unattended-upgrade
 dpkg-maintscript-helper              openssl                            unattended-upgrades
 dpkg-query                           openvt                             uncompress
 dpkg-realpath                        pager                              unexpand
 dpkg-split                           partx                              unicode_start
 dpkg-statoverride                    passwd                             unicode_stop
 dpkg-trigger                         paste                              uniq
 du                                   pastebinit                         unlink
 dumpkeys                             patch                              unlzma
 dwp                                  pathchk                            unshare
 eatmydata                            pbget                              unsquashfs
 ec2metadata                          pbput                              unxz
 echo                                 pbputs                             update-alternatives
 ed                                   pdb3                               update-mime-database
 editor                               pdb3.12                            uptime
 egrep                                peekfd                             users
 eject                                perl                               utmpdump
 elfedit                              perl5.38-x86_64-linux-gnu          uuidgen
 enc2xs                               perl5.38.2                         uuidparse
 encguess                             perlbug                            varlinkctl
 env                                  perldoc                            vcs-run
 envsubst                             perlivp                            vdir
 eqn                                  perlthanks                         vi
 ex                                   pgrep                              view
 expand                               pic                                vigpg
 expiry                               pico                               vim
 expr                                 piconv                             vim.basic
 factor                               pidof                              vim.tiny
 faillog                              pidwait                            vimdiff
 fallocate                            pinentry                           vimtutor
 false                                pinentry-curses                    vmstat
 fc-cache                             ping                               w
 fc-cat                               ping4                              wall
 fc-conflist                          ping6                              watch
 fc-list                              pinky                              watchgnupg
 fc-match                             pkaction                           wc
 fc-pattern                           pkcheck                            wdctl
 fc-query                             pkcon                              wget
 fc-scan                              pkill                              whatis
 fc-validate                          pkmon                              whereis
 fgconsole                            pkttyagent                         which
 fgrep                                pl2pm                              which.debianutils
 file                                 pldd                               whiptail
 find                                 pmap                               who
 findmnt                              pod2html                           whoami
 flock                                pod2man                            wifi-status
 fmt                                  pod2text                           write
 fold                                 pod2usage                          wslinfo
 free                                 podchecker                         wslpath
 fuser                                pr                                 x86_64
 fusermount                           preconv                            x86_64-linux-gnu-addr2line
 fusermount3                          printenv                           x86_64-linux-gnu-ar
 gapplication                         printf                             x86_64-linux-gnu-as
 gawk                                 prlimit                            x86_64-linux-gnu-c++filt
 gawkbug                              pro                                x86_64-linux-gnu-dwp
 gdbus                                prove                              x86_64-linux-gnu-elfedit
 gdk-pixbuf-csource                   prtstat                            x86_64-linux-gnu-gold
 gdk-pixbuf-pixdata                   ps                                 x86_64-linux-gnu-gp-archive
 gdk-pixbuf-thumbnailer               psfaddtable                        x86_64-linux-gnu-gp-collect-app
 geqn                                 psfgettable                        x86_64-linux-gnu-gp-display-html
 getconf                              psfstriptable                      x86_64-linux-gnu-gp-display-src
 getent                               psfxtable                          x86_64-linux-gnu-gp-display-text
 getkeycodes                          pslog                              x86_64-linux-gnu-gprof
 getopt                               pstree                             x86_64-linux-gnu-gprofng
 gettext                              pstree.x11                         x86_64-linux-gnu-ld
 gettext.sh                           ptar                               x86_64-linux-gnu-ld.bfd
 ginstall-info                        ptardiff                           x86_64-linux-gnu-ld.gold
 gio                                  ptargrep                           x86_64-linux-gnu-nm
 gio-querymodules                     ptx                                x86_64-linux-gnu-objcopy
 git                                  purge-old-kernels                  x86_64-linux-gnu-objdump
 git-receive-pack                     pwd                                x86_64-linux-gnu-ranlib
 git-shell                            pwdx                               x86_64-linux-gnu-readelf
 git-upload-archive                   py3clean                           x86_64-linux-gnu-size
 git-upload-pack                      py3compile                         x86_64-linux-gnu-strings
 glib-compile-schemas                 py3versions                        x86_64-linux-gnu-strip
 gold                                 pybabel                            xargs
 gp-archive                           pybabel-python3                    xauth
 gp-collect-app                       pydoc3                             xdg-user-dir
 gp-display-html                      pydoc3.12                          xdg-user-dirs-update
 gp-display-src                       pygettext3                         xsubpp
 gp-display-text                      pygettext3.12                      xxd
 gpasswd                              pygmentize                         xz
 gpg                                  pyhtmlizer3                        xzcat
 gpg-agent                            pyserial-miniterm                  xzcmp
 gpg-connect-agent                    pyserial-ports                     xzdiff
 gpg-wks-client                       python3                            xzegrep
 gpgconf                              python3.12                         xzfgrep
 gpgparsemail                         ranlib                             xzgrep
 gpgsm                                rbash                              xzless
 gpgsplit                             rdma                               xzmore
 gpgtar                               readelf                            yes
 gpgv                                 readlink                           ypdomainname
 gpic                                 realpath                           zcat
 gprof                                red                                zcmp
 gprofng                              rename.ul                          zdiff
 grep                                 renice                             zdump
 gresource                            reset                              zegrep
 groff                                resizecons                         zfgrep
 grog                                 resizepart                         zforce
 grops                                resolvectl                         zgrep
 grotty                               rev                                zipdetails
 groups                               rgrep                              zless
 growpart                             rm                                 zmore
 gsettings                            rmdir                              znew
 gtbl                                 rnano
```

- ls 부터 mkdir 까지, 모든 bash 명령어가 //usr/bin 디렉토리 안에 존재한다.
- perl 과 python3 은 기본으로 설치되어 있는데, C 컴파일러는 없다.
  - 먼저 clang과 llvm 부터 설치해야겠네.

## Wget

- 웹 서버(HTTP, HTTPS, FTP)로부터 콘텐츠를 가져오는 프로그램

- 예시

```shell
# example.com의 "index.html" 제목 페이지를
# 파일로 내려받기
wget http://www.example.com/
```

- 더 복잡한 사용법은, 내가 지금 알 필요는 없을듯

## Wget 을 통해 LLVM 패키지 설치하기

- 많은 리눅스 개발자들은, 자기가 만든 애플리케이션을 리눅스에 배포시, 설치 스크립트의 웹 주소를 배포한다.
- 그리고 그 설치 스크립트를 wget 을 통해 호출하는 명령어를 같이 배포한다.
- LLVM 패키지의 설치 스크립트 실행 명령어는 다음과 같다.
  - Debian, Ubuntu 에서만 사용 가능

```shell
bash -c "$(wget -O - https://apt.llvm.org/llvm.sh)"
```

> **주의** \
> 인터넷에서 다운받은 스크립트는 절대 믿고 실행하지 말 것! \
> 적어도 다른 사람들도 이 스크립트를 많이 쓰는지 확인하고 실행할 것!

[github 검색](https://github.com/search?q=%22https%3A%2F%2Fapt.llvm.org%2Fllvm.sh%22&type=code)으로 확인해보니, 다행히도 엄청 많이 쓴다.

## LLVM 패키지 설치 스크립트 실행 명령어 실행

```
--2025-07-02 09:25:55--  https://apt.llvm.org/llvm.sh
Resolving apt.llvm.org (apt.llvm.org)... 151.101.42.49, 2a04:4e42:7a::561
Connecting to apt.llvm.org (apt.llvm.org)|151.101.42.49|:443... connected.
HTTP request sent, awaiting response... 200 OK
Length: 7394 (7.2K) [application/octet-stream]
Saving to: ‘STDOUT’

-                                                           100%[========================================================================================================================================>]   7.22K  --.-KB/s    in 0.001s

2025-07-02 09:25:56 (10.6 MB/s) - written to stdout [7394/7394]

+ CURRENT_LLVM_STABLE=19
+ BASE_URL=http://apt.llvm.org
+ NEW_DEBIAN_DISTROS=("trixie" "unstable")
+ LLVM_VERSION=19
+ ALL=0
++ lsb_release -is
+ DISTRO=Ubuntu
++ lsb_release -cs
+ VERSION_CODENAME=noble
++ lsb_release -sr
+ VERSION=24.04
+ UBUNTU_CODENAME=
+ CODENAME_FROM_ARGUMENTS=
+ source /etc/os-release
++ PRETTY_NAME='Ubuntu 24.04.1 LTS'
++ NAME=Ubuntu
++ VERSION_ID=24.04
++ VERSION='24.04.1 LTS (Noble Numbat)'
++ VERSION_CODENAME=noble
++ ID=ubuntu
++ ID_LIKE=debian
++ HOME_URL=https://www.ubuntu.com/
++ SUPPORT_URL=https://help.ubuntu.com/
++ BUG_REPORT_URL=https://bugs.launchpad.net/ubuntu/
++ PRIVACY_POLICY_URL=https://www.ubuntu.com/legal/terms-and-policies/privacy-policy
++ UBUNTU_CODENAME=noble
++ LOGO=ubuntu-logo
+ DISTRO=ubuntu
+ is_new_debian=0
+ [[ ubuntu == \d\e\b\i\a\n ]]
+ needed_binaries=(lsb_release wget gpg)
+ [[ 0 -eq 0 ]]
+ needed_binaries+=(add-apt-repository)
+ missing_binaries=()
+ using_curl=
+ for binary in "${needed_binaries[@]}"
+ command -v lsb_release
+ for binary in "${needed_binaries[@]}"
+ command -v wget
+ for binary in "${needed_binaries[@]}"
+ command -v gpg
+ for binary in "${needed_binaries[@]}"
+ command -v add-apt-repository
+ [[ 0 -gt 0 ]]
+ case ${DISTRO} in
+ [[ -n noble ]]
+ CODENAME=noble
+ [[ -n noble ]]
+ LINKNAME=-noble
+ '[' 0 -ge 1 ']'
+ getopts :hm:n: arg
+ [[ 1000 -ne 0 ]]
+ echo 'This script must be run as root!'
This script must be run as root!
+ exit 1
```

아, 관리자 권한에서 실행해야 하는구나.

- 다음 명령어를 대신 실행

```shell
sudo -- bash -c "$(wget -O - https://apt.llvm.org/llvm.sh)"
```

```
--2025-07-02 09:31:34--  https://apt.llvm.org/llvm.sh
Resolving apt.llvm.org (apt.llvm.org)... 146.75.42.49, 2a04:4e42:7a::561
Connecting to apt.llvm.org (apt.llvm.org)|146.75.42.49|:443... connected.
HTTP request sent, awaiting response... 200 OK
Length: 7394 (7.2K) [application/octet-stream]
Saving to: ‘STDOUT’

-                                                           100%[========================================================================================================================================>]   7.22K  --.-KB/s    in 0s

2025-07-02 09:31:35 (17.1 MB/s) - written to stdout [7394/7394]

[sudo] password for nemonuri:
```

갑자기 root user 비밀번호를 입력하라고 하네. 입력 완료.

```
+ CURRENT_LLVM_STABLE=19
+ BASE_URL=http://apt.llvm.org
+ NEW_DEBIAN_DISTROS=("trixie" "unstable")
+ LLVM_VERSION=19
+ ALL=0
++ lsb_release -is
+ DISTRO=Ubuntu
++ lsb_release -cs
+ VERSION_CODENAME=noble
++ lsb_release -sr
+ VERSION=24.04
+ UBUNTU_CODENAME=
+ CODENAME_FROM_ARGUMENTS=
+ source /etc/os-release
++ PRETTY_NAME='Ubuntu 24.04.1 LTS'
++ NAME=Ubuntu
++ VERSION_ID=24.04
++ VERSION='24.04.1 LTS (Noble Numbat)'
++ VERSION_CODENAME=noble
++ ID=ubuntu
++ ID_LIKE=debian
++ HOME_URL=https://www.ubuntu.com/
++ SUPPORT_URL=https://help.ubuntu.com/
++ BUG_REPORT_URL=https://bugs.launchpad.net/ubuntu/
++ PRIVACY_POLICY_URL=https://www.ubuntu.com/legal/terms-and-policies/privacy-policy
++ UBUNTU_CODENAME=noble
++ LOGO=ubuntu-logo
+ DISTRO=ubuntu
+ is_new_debian=0
+ [[ ubuntu == \d\e\b\i\a\n ]]
+ needed_binaries=(lsb_release wget gpg)
+ [[ 0 -eq 0 ]]
+ needed_binaries+=(add-apt-repository)
+ missing_binaries=()
+ using_curl=
+ for binary in "${needed_binaries[@]}"
+ command -v lsb_release
+ for binary in "${needed_binaries[@]}"
+ command -v wget
+ for binary in "${needed_binaries[@]}"
+ command -v gpg
+ for binary in "${needed_binaries[@]}"
+ command -v add-apt-repository
+ [[ 0 -gt 0 ]]
+ case ${DISTRO} in
+ [[ -n noble ]]
+ CODENAME=noble
+ [[ -n noble ]]
+ LINKNAME=-noble
+ '[' 0 -ge 1 ']'
+ getopts :hm:n: arg
+ [[ 0 -ne 0 ]]
+ declare -A LLVM_VERSION_PATTERNS
+ LLVM_VERSION_PATTERNS[9]=-9
+ LLVM_VERSION_PATTERNS[10]=-10
+ LLVM_VERSION_PATTERNS[11]=-11
+ LLVM_VERSION_PATTERNS[12]=-12
+ LLVM_VERSION_PATTERNS[13]=-13
+ LLVM_VERSION_PATTERNS[14]=-14
+ LLVM_VERSION_PATTERNS[15]=-15
+ LLVM_VERSION_PATTERNS[16]=-16
+ LLVM_VERSION_PATTERNS[17]=-17
+ LLVM_VERSION_PATTERNS[18]=-18
+ LLVM_VERSION_PATTERNS[19]=-19
+ LLVM_VERSION_PATTERNS[20]=-20
+ LLVM_VERSION_PATTERNS[21]=
+ '[' '!' _ ']'
+ LLVM_VERSION_STRING=-19
+ [[ -n noble ]]
+ REPO_NAME='deb http://apt.llvm.org/noble/  llvm-toolchain-noble-19 main'
+ wget -q --method=HEAD http://apt.llvm.org/noble
+ [[ ! -f /etc/apt/trusted.gpg.d/apt.llvm.org.asc ]]
+ [[ -z '' ]]
+ wget -qO- https://apt.llvm.org/llvm-snapshot.gpg.key
+ tee /etc/apt/trusted.gpg.d/apt.llvm.org.asc
-----BEGIN PGP PUBLIC KEY BLOCK-----
Version: GnuPG v1.4.12 (GNU/Linux)

mQINBFE9lCwBEADi0WUAApM/mgHJRU8lVkkw0CHsZNpqaQDNaHefD6Rw3S4LxNmM
EZaOTkhP200XZM8lVdbfUW9xSjA3oPldc1HG26NjbqqCmWpdo2fb+r7VmU2dq3NM
R18ZlKixiLDE6OUfaXWKamZsXb6ITTYmgTO6orQWYrnW6ckYHSeaAkW0wkDAryl2
B5v8aoFnQ1rFiVEMo4NGzw4UX+MelF7rxaaregmKVTPiqCOSPJ1McC1dHFN533FY
Wh/RVLKWo6npu+owtwYFQW+zyQhKzSIMvNujFRzhIxzxR9Gn87MoLAyfgKEzrbbT
DhqqNXTxS4UMUKCQaO93TzetX/EBrRpJj+vP640yio80h4Dr5pAd7+LnKwgpTDk1
G88bBXJAcPZnTSKu9I2c6KY4iRNbvRz4i+ZdwwZtdW4nSdl2792L7Sl7Nc44uLL/
ZqkKDXEBF6lsX5XpABwyK89S/SbHOytXv9o4puv+65Ac5/UShspQTMSKGZgvDauU
cs8kE1U9dPOqVNCYq9Nfwinkf6RxV1k1+gwtclxQuY7UpKXP0hNAXjAiA5KS5Crq
7aaJg9q2F4bub0mNU6n7UI6vXguF2n4SEtzPRk6RP+4TiT3bZUsmr+1ktogyOJCc
Ha8G5VdL+NBIYQthOcieYCBnTeIH7D3Sp6FYQTYtVbKFzmMK+36ERreL/wARAQAB
tD1TeWx2ZXN0cmUgTGVkcnUgLSBEZWJpYW4gTExWTSBwYWNrYWdlcyA8c3lsdmVz
dHJlQGRlYmlhbi5vcmc+iQI4BBMBAgAiBQJRPZQsAhsDBgsJCAcDAgYVCAIJCgsE
FgIDAQIeAQIXgAAKCRAVz00Yr090Ibx+EADArS/hvkDF8juWMXxh17CgR0WZlHCC
9CTBWkg5a0bNN/3bb97cPQt/vIKWjQtkQpav6/5JTVCSx2riL4FHYhH0iuo4iAPR
udC7Cvg8g7bSPrKO6tenQZNvQm+tUmBHgFiMBJi92AjZ/Qn1Shg7p9ITivFxpLyX
wpmnF1OKyI2Kof2rm4BFwfSWuf8Fvh7kDMRLHv+MlnK/7j/BNpKdozXxLcwoFBmn
l0WjpAH3OFF7Pvm1LJdf1DjWKH0Dc3sc6zxtmBR/KHHg6kK4BGQNnFKujcP7TVdv
gMYv84kun14pnwjZcqOtN3UJtcx22880DOQzinoMs3Q4w4o05oIF+sSgHViFpc3W
R0v+RllnH05vKZo+LDzc83DQVrdwliV12eHxrMQ8UYg88zCbF/cHHnlzZWAJgftg
hB08v1BKPgYRUzwJ6VdVqXYcZWEaUJmQAPuAALyZESw94hSo28FAn0/gzEc5uOYx
K+xG/lFwgAGYNb3uGM5m0P6LVTfdg6vDwwOeTNIExVk3KVFXeSQef2ZMkhwA7wya
KJptkb62wBHFE+o9TUdtMCY6qONxMMdwioRE5BYNwAsS1PnRD2+jtlI0DzvKHt7B
MWd8hnoUKhMeZ9TNmo+8CpsAtXZcBho0zPGz/R8NlJhAWpdAZ1CmcPo83EW86Yq7
BxQUKnNHcwj2ebkCDQRRPZQsARAA4jxYmbTHwmMjqSizlMJYNuGOpIidEdx9zQ5g
zOr431/VfWq4S+VhMDhs15j9lyml0y4ok215VRFwrAREDg6UPMr7ajLmBQGau0Fc
bvZJ90l4NjXp5p0NEE/qOb9UEHT7EGkEhaZ1ekkWFTWCgsy7rRXfZLxB6sk7pzLC
DshyW3zjIakWAnpQ5j5obiDy708pReAuGB94NSyb1HoW/xGsGgvvCw4r0w3xPStw
F1PhmScE6NTBIfLliea3pl8vhKPlCh54Hk7I8QGjo1ETlRP4Qll1ZxHJ8u25f/ta
RES2Aw8Hi7j0EVcZ6MT9JWTI83yUcnUlZPZS2HyeWcUj+8nUC8W4N8An+aNps9l/
21inIl2TbGo3Yn1JQLnA1YCoGwC34g8QZTJhElEQBN0X29ayWW6OdFx8MDvllbBV
ymmKq2lK1U55mQTfDli7S3vfGz9Gp/oQwZ8bQpOeUkc5hbZszYwP4RX+68xDPfn+
M9udl+qW9wu+LyePbW6HX90LmkhNkkY2ZzUPRPDHZANU5btaPXc2H7edX4y4maQa
xenqD0lGh9LGz/mps4HEZtCI5CY8o0uCMF3lT0XfXhuLksr7Pxv57yue8LLTItOJ
d9Hmzp9G97SRYYeqU+8lyNXtU2PdrLLq7QHkzrsloG78lCpQcalHGACJzrlUWVP/
fN3Ht3kAEQEAAYkCHwQYAQIACQUCUT2ULAIbDAAKCRAVz00Yr090IbhWEADbr50X
OEXMIMGRLe+YMjeMX9NG4jxs0jZaWHc/WrGR+CCSUb9r6aPXeLo+45949uEfdSsB
pbaEdNWxF5Vr1CSjuO5siIlgDjmT655voXo67xVpEN4HhMrxugDJfCa6z97P0+ML
PdDxim57uNqkam9XIq9hKQaurxMAECDPmlEXI4QT3eu5qw5/knMzDMZj4Vi6hovL
wvvAeLHO/jsyfIdNmhBGU2RWCEZ9uo/MeerPHtRPfg74g+9PPfP6nyHD2Wes6yGd
oVQwtPNAQD6Cj7EaA2xdZYLJ7/jW6yiPu98FFWP74FN2dlyEA2uVziLsfBrgpS4l
tVOlrO2YzkkqUGrybzbLpj6eeHx+Cd7wcjI8CalsqtL6cG8cUEjtWQUHyTbQWAgG
5VPEgIAVhJ6RTZ26i/G+4J8neKyRs4vz+57UGwY6zI4AB1ZcWGEE3Bf+CDEDgmnP
LSwbnHefK9IljT9XU98PelSryUO/5UPw7leE0akXKB4DtekToO226px1VnGp3Bov
1GBGvpHvL2WizEwdk+nfk8LtrLzej+9FtIcq3uIrYnsac47Pf7p0otcFeTJTjSq3
krCaoG4Hx0zGQG2ZFpHrSrZTVy6lxvIdfi0beMgY6h78p6M9eYZHQHc02DjFkQXN
bXb5c6gCHESH5PXwPU4jQEE7Ib9J6sbk7ZT2Mw==
=j+4q
-----END PGP PUBLIC KEY BLOCK-----
++ apt-key list
++ grep -i llvm
+ [[ -z /etc/apt/trusted.gpg.d/apt.llvm.org.asc
uid           [ unknown] Sylvestre Ledru - Debian LLVM packages <sylvestre@debian.org> ]]
+ [[ noble == \b\o\o\k\w\o\r\m ]]
+ [[ 0 -eq 1 ]]
+ add-apt-repository -y 'deb http://apt.llvm.org/noble/  llvm-toolchain-noble-19 main'
Repository: 'deb http://apt.llvm.org/noble/ llvm-toolchain-noble-19 main'
Description:
Archive for codename: llvm-toolchain-noble-19 components: main
More info: http://apt.llvm.org/noble/
Adding repository.
Adding deb entry to /etc/apt/sources.list.d/archive_uri-http_apt_llvm_org_noble_-noble.list
Adding disabled deb-src entry to /etc/apt/sources.list.d/archive_uri-http_apt_llvm_org_noble_-noble.list
Hit:1 http://security.ubuntu.com/ubuntu noble-security InRelease
Get:2 https://apt.llvm.org/noble llvm-toolchain-noble-19 InRelease [5554 B]
Get:3 https://apt.llvm.org/noble llvm-toolchain-noble-19/main amd64 Packages [12.7 kB]
Hit:4 http://archive.ubuntu.com/ubuntu noble InRelease
Hit:5 http://archive.ubuntu.com/ubuntu noble-updates InRelease
Hit:6 http://archive.ubuntu.com/ubuntu noble-backports InRelease
Fetched 18.3 kB in 3s (7153 B/s)
Reading package lists... Done
+ apt-get update
Hit:2 http://security.ubuntu.com/ubuntu noble-security InRelease
Hit:1 https://apt.llvm.org/noble llvm-toolchain-noble-19 InRelease
Hit:3 http://archive.ubuntu.com/ubuntu noble InRelease
Hit:4 http://archive.ubuntu.com/ubuntu noble-updates InRelease
Hit:5 http://archive.ubuntu.com/ubuntu noble-backports InRelease
Reading package lists... Done
+ PKG='clang-19 lldb-19 lld-19 clangd-19'
+ [[ 0 -eq 1 ]]
+ apt-get install -y clang-19 lldb-19 lld-19 clangd-19
Reading package lists... Done
Building dependency tree... Done
Reading state information... Done
The following additional packages will be installed:
  gcc-13-base icu-devtools lib32gcc-s1 lib32stdc++6 libabsl20220623t64 libaom3 libasan8 libatomic1 libc-dev-bin
  libc-devtools libc6-dev libc6-i386 libcares2 libclang-common-19-dev libclang-cpp19 libclang-rt-19-dev libclang1-19
  libcrypt-dev libde265-0 libffi-dev libgc1 libgcc-13-dev libgd3 libgomp1 libgrpc++1.51t64 libgrpc29t64
  libheif-plugin-aomdec libheif-plugin-aomenc libheif-plugin-libde265 libheif1 libhwasan0 libicu-dev libipt2 libitm1
  liblldb-19 libllvm19 liblsan0 libncurses-dev libncurses6 libobjc-13-dev libobjc4 libpfm4 libprotobuf32t64
  libprotoc32t64 libquadmath0 libre2-10 libstdc++-13-dev libtsan2 libubsan1 libxml2-dev libxpm4 linux-libc-dev llvm-19
  llvm-19-dev llvm-19-linker-tools llvm-19-runtime llvm-19-tools manpages-dev python3-lldb-19 rpcsvc-proto
Suggested packages:
  clang-19-doc wasi-libc glibc-doc libgd-tools libheif-plugin-x265 libheif-plugin-ffmpegdec libheif-plugin-jpegdec
  libheif-plugin-jpegenc libheif-plugin-j2kdec libheif-plugin-j2kenc libheif-plugin-rav1e libheif-plugin-svtenc
  icu-doc ncurses-doc libstdc++-13-doc pkg-config llvm-19-doc
The following NEW packages will be installed:
  clang-19 clangd-19 gcc-13-base icu-devtools lib32gcc-s1 lib32stdc++6 libabsl20220623t64 libaom3 libasan8 libatomic1
  libc-dev-bin libc-devtools libc6-dev libc6-i386 libcares2 libclang-common-19-dev libclang-cpp19 libclang-rt-19-dev
  libclang1-19 libcrypt-dev libde265-0 libffi-dev libgc1 libgcc-13-dev libgd3 libgomp1 libgrpc++1.51t64 libgrpc29t64
  libheif-plugin-aomdec libheif-plugin-aomenc libheif-plugin-libde265 libheif1 libhwasan0 libicu-dev libipt2 libitm1
  liblldb-19 libllvm19 liblsan0 libncurses-dev libncurses6 libobjc-13-dev libobjc4 libpfm4 libprotobuf32t64
  libprotoc32t64 libquadmath0 libre2-10 libstdc++-13-dev libtsan2 libubsan1 libxml2-dev libxpm4 linux-libc-dev lld-19
  lldb-19 llvm-19 llvm-19-dev llvm-19-linker-tools llvm-19-runtime llvm-19-tools manpages-dev python3-lldb-19
  rpcsvc-proto
0 upgraded, 64 newly installed, 0 to remove and 88 not upgraded.
Need to get 183 MB of archives.
After this operation, 986 MB of additional disk space will be used.
Get:3 http://archive.ubuntu.com/ubuntu noble/main amd64 libncurses6 amd64 6.4+20240113-1ubuntu2 [112 kB]
Get:1 https://apt.llvm.org/noble llvm-toolchain-noble-19/main amd64 libllvm19 amd64 1:19.1.7~++20250114103332+cd708029e0b2-1~exp1~20250114103446.78 [28.7 MB]
Get:7 http://archive.ubuntu.com/ubuntu noble-updates/main amd64 gcc-13-base amd64 13.3.0-6ubuntu2~24.04 [51.5 kB]
Get:9 http://archive.ubuntu.com/ubuntu noble-updates/main amd64 libgomp1 amd64 14.2.0-4ubuntu2~24.04 [148 kB]
Get:10 http://archive.ubuntu.com/ubuntu noble-updates/main amd64 libitm1 amd64 14.2.0-4ubuntu2~24.04 [29.7 kB]
Get:11 http://archive.ubuntu.com/ubuntu noble-updates/main amd64 libatomic1 amd64 14.2.0-4ubuntu2~24.04 [10.5 kB]
Get:12 http://archive.ubuntu.com/ubuntu noble-updates/main amd64 libasan8 amd64 14.2.0-4ubuntu2~24.04 [3031 kB]
Get:16 http://archive.ubuntu.com/ubuntu noble-updates/main amd64 liblsan0 amd64 14.2.0-4ubuntu2~24.04 [1322 kB]
Get:17 http://archive.ubuntu.com/ubuntu noble-updates/main amd64 libtsan2 amd64 14.2.0-4ubuntu2~24.04 [2772 kB]
Get:18 http://archive.ubuntu.com/ubuntu noble-updates/main amd64 libubsan1 amd64 14.2.0-4ubuntu2~24.04 [1184 kB]
Get:20 http://archive.ubuntu.com/ubuntu noble-updates/main amd64 libhwasan0 amd64 14.2.0-4ubuntu2~24.04 [1641 kB]
Get:21 http://archive.ubuntu.com/ubuntu noble-updates/main amd64 libquadmath0 amd64 14.2.0-4ubuntu2~24.04 [153 kB]
Get:22 http://archive.ubuntu.com/ubuntu noble-updates/main amd64 libgcc-13-dev amd64 13.3.0-6ubuntu2~24.04 [2681 kB]
Get:24 http://archive.ubuntu.com/ubuntu noble-updates/main amd64 libc-dev-bin amd64 2.39-0ubuntu8.4 [20.4 kB]
Get:25 http://archive.ubuntu.com/ubuntu noble-updates/main amd64 linux-libc-dev amd64 6.8.0-63.66 [1878 kB]
Get:27 http://archive.ubuntu.com/ubuntu noble/main amd64 libcrypt-dev amd64 1:4.4.36-4build1 [112 kB]
Get:28 http://archive.ubuntu.com/ubuntu noble/main amd64 rpcsvc-proto amd64 1.4.2-0ubuntu7 [67.4 kB]
Get:29 http://archive.ubuntu.com/ubuntu noble-updates/main amd64 libc6-dev amd64 2.39-0ubuntu8.4 [2124 kB]
Get:30 http://archive.ubuntu.com/ubuntu noble-updates/main amd64 libstdc++-13-dev amd64 13.3.0-6ubuntu2~24.04 [2420 kB]
Get:32 http://archive.ubuntu.com/ubuntu noble/main amd64 libgc1 amd64 1:8.2.6-1build1 [90.3 kB]
Get:33 http://archive.ubuntu.com/ubuntu noble-updates/universe amd64 libobjc4 amd64 14.2.0-4ubuntu2~24.04 [47.0 kB]
Get:34 http://archive.ubuntu.com/ubuntu noble-updates/universe amd64 libobjc-13-dev amd64 13.3.0-6ubuntu2~24.04 [194 kB]
Get:35 http://archive.ubuntu.com/ubuntu noble-updates/main amd64 libabsl20220623t64 amd64 20220623.1-3.1ubuntu3.2 [423 kB]
Get:36 http://archive.ubuntu.com/ubuntu noble/main amd64 libcares2 amd64 1.27.0-1.0ubuntu1 [73.7 kB]
Get:38 http://archive.ubuntu.com/ubuntu noble-updates/main amd64 libprotobuf32t64 amd64 3.21.12-8.2ubuntu0.1 [922 kB]
Get:39 http://archive.ubuntu.com/ubuntu noble-updates/main amd64 libprotoc32t64 amd64 3.21.12-8.2ubuntu0.1 [683 kB]
Get:40 http://archive.ubuntu.com/ubuntu noble/main amd64 libre2-10 amd64 20230301-3build1 [168 kB]
Get:41 http://archive.ubuntu.com/ubuntu noble/universe amd64 libgrpc29t64 amd64 1.51.1-4.1build5 [2768 kB]
Get:43 http://archive.ubuntu.com/ubuntu noble/universe amd64 libgrpc++1.51t64 amd64 1.51.1-4.1build5 [481 kB]
Get:44 http://archive.ubuntu.com/ubuntu noble-updates/main amd64 icu-devtools amd64 74.2-1ubuntu3.1 [212 kB]
Get:45 http://archive.ubuntu.com/ubuntu noble-updates/main amd64 libc6-i386 amd64 2.39-0ubuntu8.4 [2787 kB]
Get:47 http://archive.ubuntu.com/ubuntu noble-updates/main amd64 lib32gcc-s1 amd64 14.2.0-4ubuntu2~24.04 [92.3 kB]
Get:48 http://archive.ubuntu.com/ubuntu noble-updates/main amd64 libaom3 amd64 3.8.2-2ubuntu0.1 [1941 kB]
Get:49 http://archive.ubuntu.com/ubuntu noble-updates/main amd64 libheif-plugin-aomdec amd64 1.17.6-1ubuntu4.1 [10.4 kB]
Get:50 http://archive.ubuntu.com/ubuntu noble/main amd64 libde265-0 amd64 1.0.15-1build3 [166 kB]
Get:51 http://archive.ubuntu.com/ubuntu noble-updates/main amd64 libheif-plugin-libde265 amd64 1.17.6-1ubuntu4.1 [8176 B]
Get:52 http://archive.ubuntu.com/ubuntu noble-updates/main amd64 libheif1 amd64 1.17.6-1ubuntu4.1 [275 kB]
Get:53 http://archive.ubuntu.com/ubuntu noble/main amd64 libxpm4 amd64 1:3.5.17-1build2 [36.5 kB]
Get:54 http://archive.ubuntu.com/ubuntu noble/main amd64 libgd3 amd64 2.3.3-9ubuntu5 [128 kB]
Get:55 http://archive.ubuntu.com/ubuntu noble-updates/main amd64 libc-devtools amd64 2.39-0ubuntu8.4 [29.3 kB]
Get:56 http://archive.ubuntu.com/ubuntu noble-updates/main amd64 lib32stdc++6 amd64 14.2.0-4ubuntu2~24.04 [814 kB]
Get:57 http://archive.ubuntu.com/ubuntu noble-updates/main amd64 libheif-plugin-aomenc amd64 1.17.6-1ubuntu4.1 [14.7 kB]
Get:58 http://archive.ubuntu.com/ubuntu noble-updates/main amd64 libicu-dev amd64 74.2-1ubuntu3.1 [11.9 MB]
Get:59 http://archive.ubuntu.com/ubuntu noble/main amd64 libipt2 amd64 2.0.6-1build1 [45.7 kB]
Get:60 http://archive.ubuntu.com/ubuntu noble/main amd64 libncurses-dev amd64 6.4+20240113-1ubuntu2 [384 kB]
Get:61 http://archive.ubuntu.com/ubuntu noble-updates/main amd64 libxml2-dev amd64 2.9.14+dfsg-1.3ubuntu3.3 [780 kB]
Get:62 http://archive.ubuntu.com/ubuntu noble/universe amd64 libpfm4 amd64 4.13.0+git32-g0d4ed0e-1 [414 kB]
Get:63 http://archive.ubuntu.com/ubuntu noble/main amd64 libffi-dev amd64 3.4.6-1build1 [62.8 kB]
Get:64 http://archive.ubuntu.com/ubuntu noble/main amd64 manpages-dev all 6.7-2 [2013 kB]
Get:2 https://apt.llvm.org/noble llvm-toolchain-noble-19/main amd64 libclang-cpp19 amd64 1:19.1.7~++20250114103332+cd708029e0b2-1~exp1~20250114103446.78 [14.3 MB]
Get:4 https://apt.llvm.org/noble llvm-toolchain-noble-19/main amd64 libclang-common-19-dev amd64 1:19.1.7~++20250114103332+cd708029e0b2-1~exp1~20250114103446.78 [744 kB]
Get:5 https://apt.llvm.org/noble llvm-toolchain-noble-19/main amd64 llvm-19-linker-tools amd64 1:19.1.7~++20250114103332+cd708029e0b2-1~exp1~20250114103446.78 [1370 kB]
Get:6 https://apt.llvm.org/noble llvm-toolchain-noble-19/main amd64 libclang1-19 amd64 1:19.1.7~++20250114103332+cd708029e0b2-1~exp1~20250114103446.78 [8321 kB]
Get:8 https://apt.llvm.org/noble llvm-toolchain-noble-19/main amd64 clang-19 amd64 1:19.1.7~++20250114103332+cd708029e0b2-1~exp1~20250114103446.78 [119 kB]
Get:13 https://apt.llvm.org/noble llvm-toolchain-noble-19/main amd64 clangd-19 amd64 1:19.1.7~++20250114103332+cd708029e0b2-1~exp1~20250114103446.78 [3551 kB]
Get:14 https://apt.llvm.org/noble llvm-toolchain-noble-19/main amd64 libclang-rt-19-dev amd64 1:19.1.7~++20250114103332+cd708029e0b2-1~exp1~20250114103446.78 [3912 kB]
Get:15 https://apt.llvm.org/noble llvm-toolchain-noble-19/main amd64 liblldb-19 amd64 1:19.1.7~++20250114103332+cd708029e0b2-1~exp1~20250114103446.78 [4487 kB]
Get:19 https://apt.llvm.org/noble llvm-toolchain-noble-19/main amd64 lld-19 amd64 1:19.1.7~++20250114103332+cd708029e0b2-1~exp1~20250114103446.78 [1491 kB]
Get:23 https://apt.llvm.org/noble llvm-toolchain-noble-19/main amd64 python3-lldb-19 amd64 1:19.1.7~++20250114103332+cd708029e0b2-1~exp1~20250114103446.78 [160 kB]
Get:26 https://apt.llvm.org/noble llvm-toolchain-noble-19/main amd64 lldb-19 amd64 1:19.1.7~++20250114103332+cd708029e0b2-1~exp1~20250114103446.78 [1305 kB]
Get:31 https://apt.llvm.org/noble llvm-toolchain-noble-19/main amd64 llvm-19-runtime amd64 1:19.1.7~++20250114103332+cd708029e0b2-1~exp1~20250114103446.78 [594 kB]
Get:37 https://apt.llvm.org/noble llvm-toolchain-noble-19/main amd64 llvm-19 amd64 1:19.1.7~++20250114103332+cd708029e0b2-1~exp1~20250114103446.78 [17.9 MB]
Get:42 https://apt.llvm.org/noble llvm-toolchain-noble-19/main amd64 llvm-19-tools amd64 1:19.1.7~++20250114103332+cd708029e0b2-1~exp1~20250114103446.78 [542 kB]
Get:46 https://apt.llvm.org/noble llvm-toolchain-noble-19/main amd64 llvm-19-dev amd64 1:19.1.7~++20250114103332+cd708029e0b2-1~exp1~20250114103446.78 [47.5 MB]
Fetched 183 MB in 35s (5249 kB/s)
Extracting templates from packages: 100%
Selecting previously unselected package libncurses6:amd64.
(Reading database ... 40792 files and directories currently installed.)
Preparing to unpack .../00-libncurses6_6.4+20240113-1ubuntu2_amd64.deb ...
Unpacking libncurses6:amd64 (6.4+20240113-1ubuntu2) ...
Selecting previously unselected package libllvm19:amd64.
Preparing to unpack .../01-libllvm19_1%3a19.1.7~++20250114103332+cd708029e0b2-1~exp1~20250114103446.78_amd64.deb ...
Unpacking libllvm19:amd64 (1:19.1.7~++20250114103332+cd708029e0b2-1~exp1~20250114103446.78) ...
Selecting previously unselected package libclang-cpp19.
Preparing to unpack .../02-libclang-cpp19_1%3a19.1.7~++20250114103332+cd708029e0b2-1~exp1~20250114103446.78_amd64.deb ...
Unpacking libclang-cpp19 (1:19.1.7~++20250114103332+cd708029e0b2-1~exp1~20250114103446.78) ...
Selecting previously unselected package gcc-13-base:amd64.
Preparing to unpack .../03-gcc-13-base_13.3.0-6ubuntu2~24.04_amd64.deb ...
Unpacking gcc-13-base:amd64 (13.3.0-6ubuntu2~24.04) ...
Selecting previously unselected package libgomp1:amd64.
Preparing to unpack .../04-libgomp1_14.2.0-4ubuntu2~24.04_amd64.deb ...
Unpacking libgomp1:amd64 (14.2.0-4ubuntu2~24.04) ...
Selecting previously unselected package libitm1:amd64.
Preparing to unpack .../05-libitm1_14.2.0-4ubuntu2~24.04_amd64.deb ...
Unpacking libitm1:amd64 (14.2.0-4ubuntu2~24.04) ...
Selecting previously unselected package libatomic1:amd64.
Preparing to unpack .../06-libatomic1_14.2.0-4ubuntu2~24.04_amd64.deb ...
Unpacking libatomic1:amd64 (14.2.0-4ubuntu2~24.04) ...
Selecting previously unselected package libasan8:amd64.
Preparing to unpack .../07-libasan8_14.2.0-4ubuntu2~24.04_amd64.deb ...
Unpacking libasan8:amd64 (14.2.0-4ubuntu2~24.04) ...
Selecting previously unselected package liblsan0:amd64.
Preparing to unpack .../08-liblsan0_14.2.0-4ubuntu2~24.04_amd64.deb ...
Unpacking liblsan0:amd64 (14.2.0-4ubuntu2~24.04) ...
Selecting previously unselected package libtsan2:amd64.
Preparing to unpack .../09-libtsan2_14.2.0-4ubuntu2~24.04_amd64.deb ...
Unpacking libtsan2:amd64 (14.2.0-4ubuntu2~24.04) ...
Selecting previously unselected package libubsan1:amd64.
Preparing to unpack .../10-libubsan1_14.2.0-4ubuntu2~24.04_amd64.deb ...
Unpacking libubsan1:amd64 (14.2.0-4ubuntu2~24.04) ...
Selecting previously unselected package libhwasan0:amd64.
Preparing to unpack .../11-libhwasan0_14.2.0-4ubuntu2~24.04_amd64.deb ...
Unpacking libhwasan0:amd64 (14.2.0-4ubuntu2~24.04) ...
Selecting previously unselected package libquadmath0:amd64.
Preparing to unpack .../12-libquadmath0_14.2.0-4ubuntu2~24.04_amd64.deb ...
Unpacking libquadmath0:amd64 (14.2.0-4ubuntu2~24.04) ...
Selecting previously unselected package libgcc-13-dev:amd64.
Preparing to unpack .../13-libgcc-13-dev_13.3.0-6ubuntu2~24.04_amd64.deb ...
Unpacking libgcc-13-dev:amd64 (13.3.0-6ubuntu2~24.04) ...
Selecting previously unselected package libc-dev-bin.
Preparing to unpack .../14-libc-dev-bin_2.39-0ubuntu8.4_amd64.deb ...
Unpacking libc-dev-bin (2.39-0ubuntu8.4) ...
Selecting previously unselected package linux-libc-dev:amd64.
Preparing to unpack .../15-linux-libc-dev_6.8.0-63.66_amd64.deb ...
Unpacking linux-libc-dev:amd64 (6.8.0-63.66) ...
Selecting previously unselected package libcrypt-dev:amd64.
Preparing to unpack .../16-libcrypt-dev_1%3a4.4.36-4build1_amd64.deb ...
Unpacking libcrypt-dev:amd64 (1:4.4.36-4build1) ...
Selecting previously unselected package rpcsvc-proto.
Preparing to unpack .../17-rpcsvc-proto_1.4.2-0ubuntu7_amd64.deb ...
Unpacking rpcsvc-proto (1.4.2-0ubuntu7) ...
Selecting previously unselected package libc6-dev:amd64.
Preparing to unpack .../18-libc6-dev_2.39-0ubuntu8.4_amd64.deb ...
Unpacking libc6-dev:amd64 (2.39-0ubuntu8.4) ...
Selecting previously unselected package libstdc++-13-dev:amd64.
Preparing to unpack .../19-libstdc++-13-dev_13.3.0-6ubuntu2~24.04_amd64.deb ...
Unpacking libstdc++-13-dev:amd64 (13.3.0-6ubuntu2~24.04) ...
Selecting previously unselected package libgc1:amd64.
Preparing to unpack .../20-libgc1_1%3a8.2.6-1build1_amd64.deb ...
Unpacking libgc1:amd64 (1:8.2.6-1build1) ...
Selecting previously unselected package libobjc4:amd64.
Preparing to unpack .../21-libobjc4_14.2.0-4ubuntu2~24.04_amd64.deb ...
Unpacking libobjc4:amd64 (14.2.0-4ubuntu2~24.04) ...
Selecting previously unselected package libobjc-13-dev:amd64.
Preparing to unpack .../22-libobjc-13-dev_13.3.0-6ubuntu2~24.04_amd64.deb ...
Unpacking libobjc-13-dev:amd64 (13.3.0-6ubuntu2~24.04) ...
Selecting previously unselected package libclang-common-19-dev:amd64.
Preparing to unpack .../23-libclang-common-19-dev_1%3a19.1.7~++20250114103332+cd708029e0b2-1~exp1~20250114103446.78_amd64.deb ...
Unpacking libclang-common-19-dev:amd64 (1:19.1.7~++20250114103332+cd708029e0b2-1~exp1~20250114103446.78) ...
Selecting previously unselected package llvm-19-linker-tools.
Preparing to unpack .../24-llvm-19-linker-tools_1%3a19.1.7~++20250114103332+cd708029e0b2-1~exp1~20250114103446.78_amd64.deb ...
Unpacking llvm-19-linker-tools (1:19.1.7~++20250114103332+cd708029e0b2-1~exp1~20250114103446.78) ...
Selecting previously unselected package libclang1-19.
Preparing to unpack .../25-libclang1-19_1%3a19.1.7~++20250114103332+cd708029e0b2-1~exp1~20250114103446.78_amd64.deb ...
Unpacking libclang1-19 (1:19.1.7~++20250114103332+cd708029e0b2-1~exp1~20250114103446.78) ...
Selecting previously unselected package clang-19.
Preparing to unpack .../26-clang-19_1%3a19.1.7~++20250114103332+cd708029e0b2-1~exp1~20250114103446.78_amd64.deb ...
Unpacking clang-19 (1:19.1.7~++20250114103332+cd708029e0b2-1~exp1~20250114103446.78) ...
Selecting previously unselected package libabsl20220623t64:amd64.
Preparing to unpack .../27-libabsl20220623t64_20220623.1-3.1ubuntu3.2_amd64.deb ...
Unpacking libabsl20220623t64:amd64 (20220623.1-3.1ubuntu3.2) ...
Selecting previously unselected package libcares2:amd64.
Preparing to unpack .../28-libcares2_1.27.0-1.0ubuntu1_amd64.deb ...
Unpacking libcares2:amd64 (1.27.0-1.0ubuntu1) ...
Selecting previously unselected package libprotobuf32t64:amd64.
Preparing to unpack .../29-libprotobuf32t64_3.21.12-8.2ubuntu0.1_amd64.deb ...
Unpacking libprotobuf32t64:amd64 (3.21.12-8.2ubuntu0.1) ...
Selecting previously unselected package libprotoc32t64:amd64.
Preparing to unpack .../30-libprotoc32t64_3.21.12-8.2ubuntu0.1_amd64.deb ...
Unpacking libprotoc32t64:amd64 (3.21.12-8.2ubuntu0.1) ...
Selecting previously unselected package libre2-10:amd64.
Preparing to unpack .../31-libre2-10_20230301-3build1_amd64.deb ...
Unpacking libre2-10:amd64 (20230301-3build1) ...
Selecting previously unselected package libgrpc29t64:amd64.
Preparing to unpack .../32-libgrpc29t64_1.51.1-4.1build5_amd64.deb ...
Unpacking libgrpc29t64:amd64 (1.51.1-4.1build5) ...
Selecting previously unselected package libgrpc++1.51t64:amd64.
Preparing to unpack .../33-libgrpc++1.51t64_1.51.1-4.1build5_amd64.deb ...
Unpacking libgrpc++1.51t64:amd64 (1.51.1-4.1build5) ...
Selecting previously unselected package clangd-19.
Preparing to unpack .../34-clangd-19_1%3a19.1.7~++20250114103332+cd708029e0b2-1~exp1~20250114103446.78_amd64.deb ...
Unpacking clangd-19 (1:19.1.7~++20250114103332+cd708029e0b2-1~exp1~20250114103446.78) ...
Selecting previously unselected package icu-devtools.
Preparing to unpack .../35-icu-devtools_74.2-1ubuntu3.1_amd64.deb ...
Unpacking icu-devtools (74.2-1ubuntu3.1) ...
Selecting previously unselected package libc6-i386.
Preparing to unpack .../36-libc6-i386_2.39-0ubuntu8.4_amd64.deb ...
Unpacking libc6-i386 (2.39-0ubuntu8.4) ...
Selecting previously unselected package lib32gcc-s1.
Preparing to unpack .../37-lib32gcc-s1_14.2.0-4ubuntu2~24.04_amd64.deb ...
Unpacking lib32gcc-s1 (14.2.0-4ubuntu2~24.04) ...
Selecting previously unselected package libaom3:amd64.
Preparing to unpack .../38-libaom3_3.8.2-2ubuntu0.1_amd64.deb ...
Unpacking libaom3:amd64 (3.8.2-2ubuntu0.1) ...
Selecting previously unselected package libheif-plugin-aomdec:amd64.
Preparing to unpack .../39-libheif-plugin-aomdec_1.17.6-1ubuntu4.1_amd64.deb ...
Unpacking libheif-plugin-aomdec:amd64 (1.17.6-1ubuntu4.1) ...
Selecting previously unselected package libde265-0:amd64.
Preparing to unpack .../40-libde265-0_1.0.15-1build3_amd64.deb ...
Unpacking libde265-0:amd64 (1.0.15-1build3) ...
Selecting previously unselected package libheif-plugin-libde265:amd64.
Preparing to unpack .../41-libheif-plugin-libde265_1.17.6-1ubuntu4.1_amd64.deb ...
Unpacking libheif-plugin-libde265:amd64 (1.17.6-1ubuntu4.1) ...
Selecting previously unselected package libheif1:amd64.
Preparing to unpack .../42-libheif1_1.17.6-1ubuntu4.1_amd64.deb ...
Unpacking libheif1:amd64 (1.17.6-1ubuntu4.1) ...
Selecting previously unselected package libxpm4:amd64.
Preparing to unpack .../43-libxpm4_1%3a3.5.17-1build2_amd64.deb ...
Unpacking libxpm4:amd64 (1:3.5.17-1build2) ...
Selecting previously unselected package libgd3:amd64.
Preparing to unpack .../44-libgd3_2.3.3-9ubuntu5_amd64.deb ...
Unpacking libgd3:amd64 (2.3.3-9ubuntu5) ...
Selecting previously unselected package libc-devtools.
Preparing to unpack .../45-libc-devtools_2.39-0ubuntu8.4_amd64.deb ...
Unpacking libc-devtools (2.39-0ubuntu8.4) ...
Selecting previously unselected package lib32stdc++6.
Preparing to unpack .../46-lib32stdc++6_14.2.0-4ubuntu2~24.04_amd64.deb ...
Unpacking lib32stdc++6 (14.2.0-4ubuntu2~24.04) ...
Selecting previously unselected package libclang-rt-19-dev:amd64.
Preparing to unpack .../47-libclang-rt-19-dev_1%3a19.1.7~++20250114103332+cd708029e0b2-1~exp1~20250114103446.78_amd64.deb ...
Unpacking libclang-rt-19-dev:amd64 (1:19.1.7~++20250114103332+cd708029e0b2-1~exp1~20250114103446.78) ...
Selecting previously unselected package libheif-plugin-aomenc:amd64.
Preparing to unpack .../48-libheif-plugin-aomenc_1.17.6-1ubuntu4.1_amd64.deb ...
Unpacking libheif-plugin-aomenc:amd64 (1.17.6-1ubuntu4.1) ...
Selecting previously unselected package libicu-dev:amd64.
Preparing to unpack .../49-libicu-dev_74.2-1ubuntu3.1_amd64.deb ...
Unpacking libicu-dev:amd64 (74.2-1ubuntu3.1) ...
Selecting previously unselected package libipt2.
Preparing to unpack .../50-libipt2_2.0.6-1build1_amd64.deb ...
Unpacking libipt2 (2.0.6-1build1) ...
Selecting previously unselected package liblldb-19.
Preparing to unpack .../51-liblldb-19_1%3a19.1.7~++20250114103332+cd708029e0b2-1~exp1~20250114103446.78_amd64.deb ...
Unpacking liblldb-19 (1:19.1.7~++20250114103332+cd708029e0b2-1~exp1~20250114103446.78) ...
Selecting previously unselected package libncurses-dev:amd64.
Preparing to unpack .../52-libncurses-dev_6.4+20240113-1ubuntu2_amd64.deb ...
Unpacking libncurses-dev:amd64 (6.4+20240113-1ubuntu2) ...
Selecting previously unselected package libxml2-dev:amd64.
Preparing to unpack .../53-libxml2-dev_2.9.14+dfsg-1.3ubuntu3.3_amd64.deb ...
Unpacking libxml2-dev:amd64 (2.9.14+dfsg-1.3ubuntu3.3) ...
Selecting previously unselected package lld-19.
Preparing to unpack .../54-lld-19_1%3a19.1.7~++20250114103332+cd708029e0b2-1~exp1~20250114103446.78_amd64.deb ...
Unpacking lld-19 (1:19.1.7~++20250114103332+cd708029e0b2-1~exp1~20250114103446.78) ...
Selecting previously unselected package python3-lldb-19.
Preparing to unpack .../55-python3-lldb-19_1%3a19.1.7~++20250114103332+cd708029e0b2-1~exp1~20250114103446.78_amd64.deb ...
Unpacking python3-lldb-19 (1:19.1.7~++20250114103332+cd708029e0b2-1~exp1~20250114103446.78) ...
Selecting previously unselected package lldb-19.
Preparing to unpack .../56-lldb-19_1%3a19.1.7~++20250114103332+cd708029e0b2-1~exp1~20250114103446.78_amd64.deb ...
Unpacking lldb-19 (1:19.1.7~++20250114103332+cd708029e0b2-1~exp1~20250114103446.78) ...
Selecting previously unselected package llvm-19-runtime.
Preparing to unpack .../57-llvm-19-runtime_1%3a19.1.7~++20250114103332+cd708029e0b2-1~exp1~20250114103446.78_amd64.deb ...
Unpacking llvm-19-runtime (1:19.1.7~++20250114103332+cd708029e0b2-1~exp1~20250114103446.78) ...
Selecting previously unselected package libpfm4:amd64.
Preparing to unpack .../58-libpfm4_4.13.0+git32-g0d4ed0e-1_amd64.deb ...
Unpacking libpfm4:amd64 (4.13.0+git32-g0d4ed0e-1) ...
Selecting previously unselected package llvm-19.
Preparing to unpack .../59-llvm-19_1%3a19.1.7~++20250114103332+cd708029e0b2-1~exp1~20250114103446.78_amd64.deb ...
Unpacking llvm-19 (1:19.1.7~++20250114103332+cd708029e0b2-1~exp1~20250114103446.78) ...
Selecting previously unselected package libffi-dev:amd64.
Preparing to unpack .../60-libffi-dev_3.4.6-1build1_amd64.deb ...
Unpacking libffi-dev:amd64 (3.4.6-1build1) ...
Selecting previously unselected package llvm-19-tools.
Preparing to unpack .../61-llvm-19-tools_1%3a19.1.7~++20250114103332+cd708029e0b2-1~exp1~20250114103446.78_amd64.deb ...
Unpacking llvm-19-tools (1:19.1.7~++20250114103332+cd708029e0b2-1~exp1~20250114103446.78) ...
Selecting previously unselected package llvm-19-dev.
Preparing to unpack .../62-llvm-19-dev_1%3a19.1.7~++20250114103332+cd708029e0b2-1~exp1~20250114103446.78_amd64.deb ...
Unpacking llvm-19-dev (1:19.1.7~++20250114103332+cd708029e0b2-1~exp1~20250114103446.78) ...
Selecting previously unselected package manpages-dev.
Preparing to unpack .../63-manpages-dev_6.7-2_all.deb ...
Unpacking manpages-dev (6.7-2) ...
Setting up libllvm19:amd64 (1:19.1.7~++20250114103332+cd708029e0b2-1~exp1~20250114103446.78) ...
Setting up libaom3:amd64 (3.8.2-2ubuntu0.1) ...
Setting up manpages-dev (6.7-2) ...
Setting up libprotobuf32t64:amd64 (3.21.12-8.2ubuntu0.1) ...
Setting up libclang1-19 (1:19.1.7~++20250114103332+cd708029e0b2-1~exp1~20250114103446.78) ...
Setting up libre2-10:amd64 (20230301-3build1) ...
Setting up libxpm4:amd64 (1:3.5.17-1build2) ...
Setting up libclang-common-19-dev:amd64 (1:19.1.7~++20250114103332+cd708029e0b2-1~exp1~20250114103446.78) ...
Setting up linux-libc-dev:amd64 (6.8.0-63.66) ...
Setting up libgomp1:amd64 (14.2.0-4ubuntu2~24.04) ...
Setting up libffi-dev:amd64 (3.4.6-1build1) ...
Setting up libpfm4:amd64 (4.13.0+git32-g0d4ed0e-1) ...
Setting up rpcsvc-proto (1.4.2-0ubuntu7) ...
Setting up gcc-13-base:amd64 (13.3.0-6ubuntu2~24.04) ...
Setting up libncurses6:amd64 (6.4+20240113-1ubuntu2) ...
Setting up libquadmath0:amd64 (14.2.0-4ubuntu2~24.04) ...
Setting up libcares2:amd64 (1.27.0-1.0ubuntu1) ...
Setting up libatomic1:amd64 (14.2.0-4ubuntu2~24.04) ...
Setting up icu-devtools (74.2-1ubuntu3.1) ...
Setting up libipt2 (2.0.6-1build1) ...
Setting up libgc1:amd64 (1:8.2.6-1build1) ...
Setting up libubsan1:amd64 (14.2.0-4ubuntu2~24.04) ...
Setting up libhwasan0:amd64 (14.2.0-4ubuntu2~24.04) ...
Setting up libcrypt-dev:amd64 (1:4.4.36-4build1) ...
Setting up libasan8:amd64 (14.2.0-4ubuntu2~24.04) ...
Setting up libc6-i386 (2.39-0ubuntu8.4) ...
Setting up llvm-19-linker-tools (1:19.1.7~++20250114103332+cd708029e0b2-1~exp1~20250114103446.78) ...
Setting up libabsl20220623t64:amd64 (20220623.1-3.1ubuntu3.2) ...
Setting up libtsan2:amd64 (14.2.0-4ubuntu2~24.04) ...
Setting up libprotoc32t64:amd64 (3.21.12-8.2ubuntu0.1) ...
Setting up llvm-19-runtime (1:19.1.7~++20250114103332+cd708029e0b2-1~exp1~20250114103446.78) ...
Setting up libde265-0:amd64 (1.0.15-1build3) ...
Setting up libc-dev-bin (2.39-0ubuntu8.4) ...
Setting up lld-19 (1:19.1.7~++20250114103332+cd708029e0b2-1~exp1~20250114103446.78) ...
Setting up llvm-19-tools (1:19.1.7~++20250114103332+cd708029e0b2-1~exp1~20250114103446.78) ...
Setting up liblsan0:amd64 (14.2.0-4ubuntu2~24.04) ...
Setting up libitm1:amd64 (14.2.0-4ubuntu2~24.04) ...
Setting up libclang-cpp19 (1:19.1.7~++20250114103332+cd708029e0b2-1~exp1~20250114103446.78) ...
Setting up liblldb-19 (1:19.1.7~++20250114103332+cd708029e0b2-1~exp1~20250114103446.78) ...
Setting up libobjc4:amd64 (14.2.0-4ubuntu2~24.04) ...
Setting up lib32gcc-s1 (14.2.0-4ubuntu2~24.04) ...
Setting up lib32stdc++6 (14.2.0-4ubuntu2~24.04) ...
Setting up libgrpc29t64:amd64 (1.51.1-4.1build5) ...
Setting up libclang-rt-19-dev:amd64 (1:19.1.7~++20250114103332+cd708029e0b2-1~exp1~20250114103446.78) ...
Setting up libgcc-13-dev:amd64 (13.3.0-6ubuntu2~24.04) ...
Setting up libc6-dev:amd64 (2.39-0ubuntu8.4) ...
Setting up llvm-19 (1:19.1.7~++20250114103332+cd708029e0b2-1~exp1~20250114103446.78) ...
Setting up python3-lldb-19 (1:19.1.7~++20250114103332+cd708029e0b2-1~exp1~20250114103446.78) ...
Setting up libicu-dev:amd64 (74.2-1ubuntu3.1) ...
Setting up libobjc-13-dev:amd64 (13.3.0-6ubuntu2~24.04) ...
Setting up libstdc++-13-dev:amd64 (13.3.0-6ubuntu2~24.04) ...
Setting up libncurses-dev:amd64 (6.4+20240113-1ubuntu2) ...
Setting up libgrpc++1.51t64:amd64 (1.51.1-4.1build5) ...
Setting up clang-19 (1:19.1.7~++20250114103332+cd708029e0b2-1~exp1~20250114103446.78) ...
Setting up lldb-19 (1:19.1.7~++20250114103332+cd708029e0b2-1~exp1~20250114103446.78) ...
Setting up libxml2-dev:amd64 (2.9.14+dfsg-1.3ubuntu3.3) ...
Setting up llvm-19-dev (1:19.1.7~++20250114103332+cd708029e0b2-1~exp1~20250114103446.78) ...
Setting up clangd-19 (1:19.1.7~++20250114103332+cd708029e0b2-1~exp1~20250114103446.78) ...
Setting up libheif-plugin-aomdec:amd64 (1.17.6-1ubuntu4.1) ...
Setting up libheif-plugin-libde265:amd64 (1.17.6-1ubuntu4.1) ...
Setting up libheif1:amd64 (1.17.6-1ubuntu4.1) ...
Setting up libgd3:amd64 (2.3.3-9ubuntu5) ...
Setting up libc-devtools (2.39-0ubuntu8.4) ...
Setting up libheif-plugin-aomenc:amd64 (1.17.6-1ubuntu4.1) ...
Processing triggers for libc-bin (2.39-0ubuntu8.4) ...
Processing triggers for systemd (255.4-1ubuntu8.8) ...
Processing triggers for man-db (2.12.0-4build2) ...
Processing triggers for install-info (7.1-3build2) ...
```

'64'개의 패키지가 새로 설치되었다
- 나름 '의존성 관리'도 하는듯?

## clang 설치 확인해보기

1. 첫번째 시도

```shell
clang --help
```

```
Command 'clang' not found, but can be installed with:
sudo apt install clang
```

생각했던 결과가 나오지 않는다.

2. 두번째 시도

```shell
clang-19 --help
```

```
OVERVIEW: clang LLVM compiler

USAGE: clang [options] file...

OPTIONS:
(생략)
```

clang 이 아니라 clang-19?

### //usr/bin 파일 다시 확인해보기

```
 FileCheck-19                         info                               pybabel-python3
 NF                                   infobrowser                        pydoc3
 UnicodeNameMappingGenerator-19       infocmp                            pydoc3.12
 X11                                  infotocap                          pygettext3
'['                                   install                            pygettext3.12
 aa-enabled                           install-info                       pygmentize
 aa-exec                              instmodsh                          pyhtmlizer3
 aa-features-abi                      ionice                             pyserial-miniterm
 add-apt-repository                   ip                                 pyserial-ports
 addpart                              ipcmk                              python3
 addr2line                            ipcrm                              python3.12
 apport-bug                           ipcs                               ranlib
 apport-cli                           ischroot                           rbash
 apport-collect                       join                               rdma
 apport-unpack                        journalctl                         readelf
 appstreamcli                         json-patch-jsondiff                readlink
 apropos                              json_pp                            realpath
 apt                                  jsondiff                           red
 apt-add-repository                   jsonpatch                          reduce-chunk-list-19
 apt-cache                            jsonpointer                        rename.ul
 apt-cdrom                            jsonschema                         renice
 apt-config                           kbd_mode                           reset
 apt-extracttemplates                 kbdinfo                            resizecons
 apt-ftparchive                       kbxutil                            resizepart
 apt-get                              keep-one-running                   resolvectl
 apt-key                              kernel-install                     rev
 apt-mark                             kill                               rgrep
 apt-sortpkgs                         killall                            rm
 ar                                   kmod                               rmdir
 arch                                 landscape-broker                   rnano
 as                                   landscape-client                   routel
 asan_symbolize-19                    landscape-config                   rpcgen
 automat-visualize3                   landscape-manager                  rrsync
 awk                                  landscape-monitor                  rsync
 b2sum                                landscape-package-changer          rsync-ssl
 base32                               landscape-package-reporter         rtstat
 base64                               landscape-release-upgrader         run-one
 basename                             landscape-sysinfo                  run-one-constantly
 basenc                               last                               run-one-until-failure
 bash                                 lastb                              run-one-until-success
 bashbug                              lastlog                            run-parts
 bc                                   lcf                                run-this-one
 broadwayd                            ld                                 runcon
 bugpoint-19                          ld.bfd                             rview
 busctl                               ld.gold                            rvim
 byobu                                ld.lld-19                          sanstats-19
 byobu-config                         ld.so                              savelog
 byobu-ctrl-a                         ld64.lld-19                        scalar
 byobu-disable                        ldd                                scp
 byobu-disable-prompt                 less                               screendump
 byobu-enable                         lessecho                           script
 byobu-enable-prompt                  lessfile                           scriptlive
 byobu-export                         lesskey                            scriptreplay
 byobu-janitor                        lesspipe                           sdiff
 byobu-keybindings                    lexgrog                            sed
 byobu-launch                         libnetcfg                          select-editor
 byobu-launcher                       link                               sensible-browser
 byobu-launcher-install               linux32                            sensible-editor
 byobu-launcher-uninstall             linux64                            sensible-pager
 byobu-layout                         llc-19                             sensible-terminal
 byobu-prompt                         lld-19                             seq
 byobu-quiet                          lld-link-19                        session-migration
 byobu-reconnect-sockets              lldb-19                            setarch
 byobu-screen                         lldb-argdumper-19                  setfont
 byobu-select-backend                 lldb-dap-19                        setkeycodes
 byobu-select-profile                 lldb-instr-19                      setleds
 byobu-select-session                 lldb-server-19                     setlogcons
 byobu-shell                          lli-19                             setmetamode
 byobu-silent                         lli-child-target-19                setpriv
 byobu-status                         llvm-PerfectShuffle-19             setsid
 byobu-status-detail                  llvm-addr2line-19                  setterm
 byobu-tmux                           llvm-ar-19                         setupcon
 byobu-ugraph                         llvm-as-19                         sftp
 byobu-ulevel                         llvm-bcanalyzer-19                 sg
 c++filt                              llvm-bitcode-strip-19              sh
 c_rehash                             llvm-c-test-19                     sha1sum
 captoinfo                            llvm-cat-19                        sha224sum
 cat                                  llvm-cfi-verify-19                 sha256sum
 catman                               llvm-config-19                     sha384sum
 cftp3                                llvm-cov-19                        sha512sum
 chage                                llvm-cvtres-19                     shasum
 chardet                              llvm-cxxdump-19                    showconsolefont
 chardetect                           llvm-cxxfilt-19                    showkey
 chattr                               llvm-cxxmap-19                     shred
 chcon                                llvm-debuginfo-analyzer-19         shuf
 chfn                                 llvm-debuginfod-19                 size
 chgrp                                llvm-debuginfod-find-19            skill
 chmod                                llvm-diff-19                       slabtop
 choom                                llvm-dis-19                        sleep
 chown                                llvm-dlltool-19                    slogin
 chrt                                 llvm-dwarfdump-19                  snap
 chsh                                 llvm-dwarfutil-19                  snapctl
 chvt                                 llvm-dwp-19                        snapfuse
 ckbcomp                              llvm-exegesis-19                   snice
 ckeygen3                             llvm-extract-19                    soelim
 cksum                                llvm-gsymutil-19                   sort
 clang++-19                           llvm-ifs-19                        sotruss
 clang-19                             llvm-install-name-tool-19          splain
 clang-cpp-19                         llvm-jitlink-19                    split
 clangd-19                            llvm-jitlink-executor-19           split-file-19
 clear                                llvm-lib-19                        splitfont
 clear_console                        llvm-libtool-darwin-19             sprof
 cloud-id                             llvm-link-19                       sqfscat
 cloud-init                           llvm-lipo-19                       sqfstar
 cloud-init-per                       llvm-lto-19                        ss
 cmp                                  llvm-lto2-19                       ssh
 codepage                             llvm-mc-19                         ssh-add
 col                                  llvm-mca-19                        ssh-agent
 col1                                 llvm-ml-19                         ssh-argv0
 col2                                 llvm-modextract-19                 ssh-copy-id
 col3                                 llvm-mt-19                         ssh-keygen
 col4                                 llvm-nm-19                         ssh-keyscan
 col5                                 llvm-objcopy-19                    stat
 col6                                 llvm-objdump-19                    stdbuf
 col7                                 llvm-opt-report-19                 streamzip
 col8                                 llvm-otool-19                      strings
 col9                                 llvm-pdbutil-19                    strip
 colcrt                               llvm-profdata-19                   stty
 colrm                                llvm-profgen-19                    su
 column                               llvm-ranlib-19                     sudo
 comm                                 llvm-rc-19                         sudoedit
 conch3                               llvm-readelf-19                    sudoreplay
 corelist                             llvm-readobj-19                    sum
 count-19                             llvm-readtapi-19                   sync
 cp                                   llvm-reduce-19                     systemctl
 cpan                                 llvm-remarkutil-19                 systemd
 cpan5.38-x86_64-linux-gnu            llvm-rtdyld-19                     systemd-ac-power
 crontab                              llvm-sim-19                        systemd-analyze
 csplit                               llvm-size-19                       systemd-ask-password
 ctail                                llvm-split-19                      systemd-cat
 ctstat                               llvm-stress-19                     systemd-cgls
 curl                                 llvm-strings-19                    systemd-cgtop
 cut                                  llvm-strip-19                      systemd-confext
 cvtsudoers                           llvm-symbolizer-19                 systemd-creds
 dash                                 llvm-tblgen-19                     systemd-cryptenroll
 date                                 llvm-tli-checker-19                systemd-cryptsetup
 dbus-cleanup-sockets                 llvm-undname-19                    systemd-delta
 dbus-daemon                          llvm-windres-19                    systemd-detect-virt
 dbus-launch                          llvm-xray-19                       systemd-escape
 dbus-monitor                         ln                                 systemd-firstboot
 dbus-run-session                     lnstat                             systemd-hwdb
 dbus-send                            loadkeys                           systemd-id128
 dbus-update-activation-environment   loadunimap                         systemd-inhibit
 dbus-uuidgen                         locale                             systemd-machine-id-setup
 dd                                   locale-check                       systemd-mount
 deallocvt                            localectl                          systemd-notify
 deb-systemd-helper                   localedef                          systemd-path
 deb-systemd-invoke                   logger                             systemd-repart
 debconf                              login                              systemd-run
 debconf-apt-progress                 loginctl                           systemd-socket-activate
 debconf-communicate                  logname                            systemd-stdio-bridge
 debconf-copydb                       look                               systemd-sysext
 debconf-escape                       ls                                 systemd-sysusers
 debconf-set-selections               lsattr                             systemd-tmpfiles
 debconf-show                         lsb_release                        systemd-tty-ask-password-agent
 debian-distro-info                   lsblk                              systemd-umount
 delpart                              lscpu                              tabs
 derb                                 lshw                               tac
 df                                   lsipc                              tail
 dh_bash-completion                   lslocks                            tar
 dh_installxmlcatalogs                lslogins                           taskset
 diff                                 lsmem                              tbl
 diff3                                lsmod                              tee
 dir                                  lsns                               tempfile
 dircolors                            lsof                               test
 dirmngr                              lspgpot                            tic
 dirmngr-client                       lzcat                              time
 dirname                              lzcmp                              timedatectl
 distro-info                          lzdiff                             timeout
 dmesg                                lzegrep                            tkconch3
 dnsdomainname                        lzfgrep                            tload
 do-release-upgrade                   lzgrep                             tmux
 domainname                           lzless                             toe
 dpkg                                 lzma                               top
 dpkg-deb                             lzmainfo                           touch
 dpkg-divert                          lzmore                             tput
 dpkg-maintscript-helper              mailmail3                          tr
 dpkg-query                           makeconv                           trial3
 dpkg-realpath                        man                                troff
 dpkg-split                           man-recode                         true
 dpkg-statoverride                    mandb                              truncate
 dpkg-trigger                         manifest                           tset
 dsymutil-19                          manpath                            tsort
 du                                   mapscrn                            tty
 dumpkeys                             markdown-it                        twist3
 dwp                                  mawk                               twistd3
 eatmydata                            mcookie                            tzselect
 ec2metadata                          md5sum                             ua
 echo                                 md5sum.textutils                   ubuntu-advantage
 ed                                   memusage                           ubuntu-bug
 editor                               memusagestat                       ubuntu-distro-info
 egrep                                mesa-overlay-control.py            ubuntu-security-status
 eject                                mesg                               ucf
 elfedit                              migrate-pubring-from-classic-gpg   ucfq
 enc2xs                               mk_modmap                          ucfr
 encguess                             mkdir                              uclampset
 env                                  mkfifo                             uconv
 envsubst                             mknod                              udevadm
 eqn                                  mksquashfs                         ul
 ex                                   mktemp                             umount
 expand                               more                               uname
 expiry                               mount                              unattended-upgrade
 expr                                 mountpoint                         unattended-upgrades
 factor                               mtrace                             uncompress
 faillog                              mv                                 unexpand
 fallocate                            namei                              unicode_start
 false                                nano                               unicode_stop
 fc-cache                             nawk                               uniq
 fc-cat                               nc                                 unlink
 fc-conflist                          nc.openbsd                         unlzma
 fc-list                              ncurses6-config                    unshare
 fc-match                             ncursesw6-config                   unsquashfs
 fc-pattern                           neqn                               unxz
 fc-query                             netcat                             update-alternatives
 fc-scan                              networkctl                         update-mime-database
 fc-validate                          networkd-dispatcher                uptime
 fgconsole                            newgrp                             users
 fgrep                                ngettext                           utmpdump
 file                                 nice                               uuidgen
 find                                 nisdomainname                      uuidparse
 findmnt                              nl                                 varlinkctl
 flock                                nm                                 vcs-run
 fmt                                  nohup                              vdir
 fold                                 not-19                             verify-uselistorder-19
 free                                 nproc                              vi
 fuser                                nroff                              view
 fusermount                           nsenter                            vigpg
 fusermount3                          nstat                              vim
 gapplication                         numfmt                             vim.basic
 gawk                                 obj2yaml-19                        vim.tiny
 gawkbug                              objcopy                            vimdiff
 gdbus                                objdump                            vimtutor
 gdk-pixbuf-csource                   od                                 vmstat
 gdk-pixbuf-pixdata                   oem-getlogs                        w
 gdk-pixbuf-thumbnailer               openssl                            wall
 genbrk                               openvt                             wasm-ld-19
 gencat                               opt-19                             watch
 gencfu                               pager                              watchgnupg
 gencnval                             partx                              wc
 gendict                              passwd                             wdctl
 genrb                                paste                              wget
 geqn                                 pastebinit                         whatis
 getconf                              patch                              whereis
 getent                               pathchk                            which
 getkeycodes                          pbget                              which.debianutils
 getopt                               pbput                              whiptail
 gettext                              pbputs                             who
 gettext.sh                           pdb3                               whoami
 ginstall-info                        pdb3.12                            wifi-status
 gio                                  peekfd                             write
 gio-querymodules                     perl                               wslinfo
 git                                  perl5.38-x86_64-linux-gnu          wslpath
 git-receive-pack                     perl5.38.2                         x86_64
 git-shell                            perlbug                            x86_64-linux-gnu-addr2line
 git-upload-archive                   perldoc                            x86_64-linux-gnu-ar
 git-upload-pack                      perlivp                            x86_64-linux-gnu-as
 glib-compile-schemas                 perlthanks                         x86_64-linux-gnu-c++filt
 gold                                 pgrep                              x86_64-linux-gnu-dwp
 gp-archive                           pic                                x86_64-linux-gnu-elfedit
 gp-collect-app                       pico                               x86_64-linux-gnu-gold
 gp-display-html                      piconv                             x86_64-linux-gnu-gp-archive
 gp-display-src                       pidof                              x86_64-linux-gnu-gp-collect-app
 gp-display-text                      pidwait                            x86_64-linux-gnu-gp-display-html
 gpasswd                              pinentry                           x86_64-linux-gnu-gp-display-src
 gpg                                  pinentry-curses                    x86_64-linux-gnu-gp-display-text
 gpg-agent                            ping                               x86_64-linux-gnu-gprof
 gpg-connect-agent                    ping4                              x86_64-linux-gnu-gprofng
 gpg-wks-client                       ping6                              x86_64-linux-gnu-ld
 gpgconf                              pinky                              x86_64-linux-gnu-ld.bfd
 gpgparsemail                         pkaction                           x86_64-linux-gnu-ld.gold
 gpgsm                                pkcheck                            x86_64-linux-gnu-nm
 gpgsplit                             pkcon                              x86_64-linux-gnu-objcopy
 gpgtar                               pkgdata                            x86_64-linux-gnu-objdump
 gpgv                                 pkill                              x86_64-linux-gnu-ranlib
 gpic                                 pkmon                              x86_64-linux-gnu-readelf
 gprof                                pkttyagent                         x86_64-linux-gnu-size
 gprofng                              pl2pm                              x86_64-linux-gnu-strings
 grep                                 pldd                               x86_64-linux-gnu-strip
 gresource                            pmap                               xargs
 groff                                pod2html                           xauth
 grog                                 pod2man                            xdg-user-dir
 grops                                pod2text                           xdg-user-dirs-update
 grotty                               pod2usage                          xml2-config
 groups                               podchecker                         xsubpp
 growpart                             pr                                 xxd
 gsettings                            preconv                            xz
 gtbl                                 printenv                           xzcat
 gtk-builder-tool                     printf                             xzcmp
 gtk-encode-symbolic-svg              prlimit                            xzdiff
 gtk-launch                           pro                                xzegrep
 gtk-query-settings                   prove                              xzfgrep
 gtk-update-icon-cache                prtstat                            xzgrep
 gunzip                               ps                                 xzless
 gzexe                                psfaddtable                        xzmore
 gzip                                 psfgettable                        yaml-bench-19
 h2ph                                 psfstriptable                      yaml2obj-19
 h2xs                                 psfxtable                          yes
 hardlink                             pslog                              ypdomainname
 hd                                   pstree                             zcat
 head                                 pstree.x11                         zcmp
 helpztags                            ptar                               zdiff
 hexdump                              ptardiff                           zdump
 hostid                               ptargrep                           zegrep
 hostname                             ptx                                zfgrep
 hostnamectl                          purge-old-kernels                  zforce
 hwe-support-status                   pwd                                zgrep
 i386                                 pwdx                               zipdetails
 iconv                                py3clean                           zless
 icuexportdata                        py3compile                         zmore
 icuinfo                              py3versions                        znew
 id                                   pybabel
```

죄다 꼬리표로 버전 '-19'가 달려 있다. 이거 괜찮은건가? 원래 이게 맞나...?

일단 뭐라도 하나 빌드 해 봐야겠는걸.

## 참고자료

- [Wget](https://ko.wikipedia.org/wiki/Wget)
- [LLVM Debian/Ubuntu nightly packages](https://apt.llvm.org/)